        async Task<void> Copy(List<string> ExcludedNamesWithoutExtensions)
        {
            string TargetDirectory = @"Copied";
            if (Directory.Exists(TargetDirectory))
            {
                Directory.Delete(TargetDirectory, true);
            }
            Directory.CreateDirectory(TargetDirectory);
            await Task.Delay(1000);
            string SourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Logger.LogInfo("Creating Backup of the Source Directory...");
            if (Directory.GetFiles(SourceDirectory).Length == 0)
            {
                Logger.LogError("No Files found in this directory. " + SourceDirectory);
                return;
            }
            else
            {
                //Now Create all of the directories         
                foreach (string dirPath in Directory.GetDirectories(SourceDirectory, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(SourceDirectory, TargetDirectory));
                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourceDirectory, "*.*", SearchOption.AllDirectories))
                {
                    bool CanCopy = true;
                        string[] array = newPath.Split('\\')[newPath.Split('\\').Length - 1].Split('.');
                        string name = array[array.Length - 1];
                    foreach (string s in ExcludedNamesWithoutExtensions)
                    {
                        if (name != s)
                        {
                             CanCopy = false;
                             break;
                        }
                    }
                    if (CanCopy)
                            File.Copy(newPath, newPath.Replace(SourceDirectory, TargetDirectory), true);
                }
            }
        }
