            using (Stream source = File.OpenRead(@"D:\temp\test.png"))
            {
                byte[] buffer = new byte[2048];
                var chunkCount = source.Length;
                for (int i = 0; i < (chunkCount / 2048) + 1; i++)
                {
                    source.Position = i * 2048;
                    // size - number of actually bytes read 
                    int size = source.Read(buffer, 0, 2048);
                    // if we bytes to write, do it
                    if (size > 0)
                        WriteFile(buffer, size);
                }
                incomingFile.Close();
            }
            private static void WriteFile(byte[] buffer, int size = -1) 
            {
               incomingFile.Write(buffer, 0, size < 0 ? buffer.Length : size);
            }
