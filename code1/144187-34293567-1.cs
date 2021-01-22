     class ProcessEnvironment : IDisposable
        {
            private Settings itsSettings;
            private string itsTempDestDirectory;
            public string WorkingDirectory { get; set; }
            public bool ExecutingFromTempDir { get { return !String.IsNullOrEmpty(itsTempDestDirectory); } }
    
            public ProcessEnvironment(Settings settings)
            {
                this.itsSettings = settings;
    
                WorkingDirectory = GetWorkingDirectory();
            }
    
            private string GetWorkingDirectory()
            {
                var dirInfo = new DirectoryInfo(itsSettings.StartupFolder);
    
                if (!IsUncDrive(dirInfo))
                    return itsSettings.StartupFolder;
    
                return CreateWorkingDirectory(dirInfo);
            }
    
            private string CreateWorkingDirectory(DirectoryInfo dirInfo)
            {
                var srcPath = dirInfo.FullName;
                itsTempDestDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(itsTempDestDirectory);
    
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(srcPath, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(srcPath, itsTempDestDirectory));
    
                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(srcPath, "*.*", SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(srcPath, itsTempDestDirectory), true);
    
                return itsTempDestDirectory;
            }
    
            private bool IsUncDrive(DirectoryInfo dirInfo)
            {
                Uri uri = null;
                if (!Uri.TryCreate(dirInfo.FullName, UriKind.Absolute, out uri))
                {
                    return false;
                }
                return uri.IsUnc;
            }
    
    
    
            public void Dispose()
            {
                try
                {
                    if (ExecutingFromTempDir)
                        Directory.Delete(itsTempDestDirectory, true);
    
                }
                catch (Exception ex)
                {  //do nothing - if we can't delete then we can't do it
                    Console.WriteLine("Failed in Dispose: " + ex);
                }
            }
        }
