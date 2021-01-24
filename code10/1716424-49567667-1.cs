     public void Download(string strPath)
        {
                var memory = GetFile(strPath);
           
                string filename = "Report_" + DateTime.Now;
                var fileStream = new FileStream(filename,
                FileMode.CreateNew,
                FileAccess.ReadWrite);
                // File.WriteAllBytes(strPath,memory.ToArray());
                fileStream.Write(memory.ToArray(),0,memory.ToArray().Length-1);
        }
