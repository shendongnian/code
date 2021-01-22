    using (System.IO.Stream input = System.IO.File.OpenRead(fileToCompress))
    {
        using (var raw = System.IO.File.Create(outputFile))
        {
            using (Stream compressor = new GZipStream(raw, CompressionMode.Compress))
            {
                byte[] buffer = new byte[WORKING_BUFFER_SIZE];
                int n;
                while ((n= input.Read(buffer, 0, buffer.Length)) != 0)
                {
                    compressor.Write(buffer, 0, n);
                }
            }
        }
    }
