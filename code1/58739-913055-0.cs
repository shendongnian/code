        public byte[] GetBinaryData(string path, int bufferSize)
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                byte[] buffer = new byte[bufferSize];
                while((bytesRead = fs.Read(buffer,0,bufferSize))>0)
                {
                    ms.Write(buffer,0,bytesRead);
                }
            }
            return(ms.ToArray());
        }
        public void SaveBinaryData(string path, byte[] data, int bufferSize)
        {
            using (FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                int totalBytesSaved = 0;
                while (totalBytesSaved<data.Length)
                {
                    int remainingBytes = Math.Min(bufferSize, data.Length - totalBytesSaved);
                    fs.Write(data, totalBytesSaved, remainingBytes);
                    totalBytesSaved += remainingBytes;
                }
            }
        }
