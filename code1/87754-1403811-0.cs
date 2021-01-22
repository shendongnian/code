    public static void SplitFile(string inputFile,
                                 string outputPrefix,
                                 int chunkSize)
    {
        byte[] buffer = new byte[chunkSize];
        using (Stream input = File.OpenRead(inputFile))
        {
            int index = 0;
            while (input.Position < input.Length)
            {
                using (Stream output = File.Create(outputPrefix + index))
                {
                    int chunkBytesRead = 0;
                    while (chunkBytesRead < chunkSize)
                    {
                        int bytesRead = input.Read(buffer, 
                                                   chunkBytesRead, 
                                                   chunkSize - chunkBytesRead);
                        // End of input
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        chunkBytesRead += bytesRead;
                    }
                    output.Write(buffer, 0, chunkBytesRead);
                }
            }
        }
    }
