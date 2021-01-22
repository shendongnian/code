    public static bool CopyTo(this DirectoryInfo source, string destination)
        {
            try
            {
                foreach (string dirPath in Directory.GetDirectories(source.FullName))
                {
                    var newDirPath = dirPath.Replace(source.FullName, destination);
                    Directory.CreateDirectory(newDirPath);
                    new DirectoryInfo(dirPath).CopyTo(newDirPath);
                }
                //Copy all the files & Replaces any files with the same name
                foreach (string filePath in Directory.GetFiles(source.FullName))
                {
                    File.Copy(filePath, filePath.Replace(source.FullName,destination), true);
                }
                return true;
            }
            catch (IOException exp)
            {
                return false;
            }
        }
