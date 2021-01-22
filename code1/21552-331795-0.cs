        public void Log(string line)
        {
            var sw = new StreamWriter(File.Open(
                "LogFile.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
            sw.WriteLine(line);
            
            // Since we don't close the stream the FileStream finalizer will do that for 
            // us but we don't know when that will be and until then the file is locked.
        }
