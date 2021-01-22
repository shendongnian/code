       public static void Copy(System.IO.Stream inStream, string outputFilePath)
        {
            int bufferSize = 1024 * 1024;
            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.SetLength(inStream.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];
                while ((bytesRead = inStream.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }
           }
        }
