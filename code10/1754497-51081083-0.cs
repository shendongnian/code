            private void copyFiles(string SourcePath, string DestinationPath)
            {
                List<string> ext = new List<string>() { ".JPG", ".JPEG", ".TIF", ".PNG" };
                DirectoryInfo di = new DirectoryInfo(SourcePath);
    
                Action shower = () =>
                {
                    circularProgressBar1.Enabled = true;
                    circularProgressBar1.Visible = true;
                    circularProgressBar1.Style = ProgressBarStyle.Marquee;
                };
                BeginInvoke(shower);
    
                var sourceFiles = di.GetFiles("*.*",SearchOption.AllDirectories).Where(f => ext.Contains(f.Extension));
                int num = sourceFiles.Count();
    
                foreach(FileInfo fi in sourceFiles)
                {
                    string newFilePath;
                    if (!Directory.Exists(DestinationPath))
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }
                    newFilePath = Path.Combine(DestinationPath, fi.Name);
    
                    File.Copy(fi.FullName, newFilePath, true);
    
                    if(fi.Length != new FileInfo(newFilePath).Length)
                    {
                        File.Delete(newFilePath);
                    }
                }
    
                Action hider = () =>
                {
                    circularProgressBar1.Enabled = false;
                    circularProgressBar1.Visible = false;
                    circularProgressBar1.Style = ProgressBarStyle.Continuous;
                };
    
                BeginInvoke(hider);
            }
