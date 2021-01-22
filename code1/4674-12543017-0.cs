        private void KCOPY(string source, string destination)
        {
            if (IsFile(source))
            {
                string target = Path.Combine(destination, Path.GetFileName(source));
                File.Copy(source, target, true);
            }
            else
            {
                string fileName = Path.GetFileName(source);
                string target = System.IO.Path.Combine(destination, fileName);
                if (!System.IO.Directory.Exists(target))
                {
                    System.IO.Directory.CreateDirectory(target);
                }
                List<string> files = GetAllFileAndFolder(source);
                foreach (string file in files)
                {
                    KCOPY(file, target);
                }
            }
        }
        private List<string> GetAllFileAndFolder(string path)
        {
            List<string> allFile = new List<string>();
            foreach (string dir in Directory.GetDirectories(path))
            {
                allFile.Add(dir);
            }
            foreach (string file in Directory.GetFiles(path))
            {
                allFile.Add(file);
            }
            return allFile;
        }
        private bool IsFile(string path)
        {
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return false;
            }
            return true;
        }
