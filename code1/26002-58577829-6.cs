    private void StreamBuffer(Stream stream, int buffer)
    {
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            var memoryBuffer = memoryStream.GetBuffer();
    
            for (int i = 0; i < memoryBuffer.Length;)
            {
                var networkBuffer = new byte[buffer];
                for (int j = 0; j < networkBuffer.Length && i < memoryBuffer.Length; j++)
                {
                    networkBuffer[j] = memoryBuffer[i];
                    i++;
                }
                //Assuming destination file
                destinationFileStream.Write(networkBuffer, 0, networkBuffer.Length);
            }
        }
    }
