    public void StreamBuffer(Stream sourceStream, Stream destinationStream, int buffer = 4096)
    {
        using (var memoryStream = new MemoryStream())
        {
            sourceStream.CopyTo(memoryStream);
            var memoryBuffer = memoryStream.GetBuffer();
            for (int i = 0; i < memoryBuffer.Length;)
            {
                var networkBuffer = new byte[buffer];
                for (int j = 0; j < networkBuffer.Length && i < memoryBuffer.Length; j++)
                {
                    networkBuffer[j] = memoryBuffer[i];
                    i++;
                }
                destinationStream.Write(networkBuffer, 0, networkBuffer.Length);
            }
        }
    }
