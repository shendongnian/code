     private void GetFilePath()
            {
                string filepath = string.Empty;
    
                var processes = Process.GetProcessesByName("exe name");
                foreach (var process in processes)
                {
                    filepath = process.MainModule.FileName;
                }
    
                return filepath;
            }
