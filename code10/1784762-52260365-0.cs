        private static void ConvertLargeFileToBase64()
        {
            var buffer = new byte[16 * 1024];
            using (var fsIn = new FileStream("D:\\in.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var fsOut = new FileStream("D:\\out.txt", FileMode.CreateNew, FileAccess.Write))
                {
                    int read;
                    while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // convert to base 64 and convert to bytes for writing back to file
                        var b64 = Encoding.ASCII.GetBytes(Convert.ToBase64String(buffer));
                        // write to the output filestream
                        fsOut.Write(b64, 0, read);
                    }
                    
                    fsOut.Close();
                }
            }
        }
