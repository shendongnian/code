    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class COPYTEST
    {
        string path = System.IO.Path.GetFullPath("./");
        private string splitString;
    
    
        public COPYTEST(string ver)
        {
            splitString = ver; // I need this for find split position in my case ver = "0.0.0.2";
    
        }
    
        public void Copy(List<string> dirList, List<string> fileList)
        {
            //Create dirs first
            for (int i = 0; i < dirList.Count; i++)
            {
                string dr = dirList[i].Substring(dirList[i].IndexOf($"{splitString}"));
                Directory.CreateDirectory(dirList[i].Replace(dirList[i], $"{path}Builds/{dr}"));
            }
    
            for (int i = 0; i < fileList.Count; i++)
            {
                string st = fileList[i].Substring(fileList[i].IndexOf($"{splitString}"));
    
                string sourceFilePath = fileList[i];
                string destinationFilePath = sourceFilePath.Replace(sourceFilePath, $"{path}Builds/{st}");
    
                int size = 2048 * 1024; //buffer size
                byte[][] buffer = new byte[2][];
                buffer[0] = new byte[size];
                buffer[1] = new byte[size];
    
                int current_read_buffer = 0; //pointer to current read buffer
                int last_bytes_read = 0; //number of bytes last read
                //Now create files
                try
                {
                    using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, size * 2, FileOptions.SequentialScan))
                    //using (FileStream fs = File.Open(<file-path>, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        FileStream writer = new FileStream(destinationFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, size * 2, true);
    
                        current_read_buffer = 0;
                        last_bytes_read = reader.Read(buffer[current_read_buffer], 0, size); //synchronously read the first buffer
                        long l = reader.Length;
                        long a = 0;
                        while (a < l)
                        {
                            IAsyncResult aw = writer.BeginWrite(buffer[current_read_buffer], 0, last_bytes_read, new AsyncCallback(CopyFileCallback), 0);
                            current_read_buffer = current_read_buffer == 0 ? 1 : 0;
                            IAsyncResult ar = reader.BeginRead(buffer[current_read_buffer], 0, size, new AsyncCallback(CopyFileCallback), 0);
                            a += last_bytes_read;
                            last_bytes_read = reader.EndRead(ar);
                            writer.EndWrite(aw);
                        }
    
                        writer.Dispose();
                        reader.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    //Log exception
                }
            }
        }
    }
