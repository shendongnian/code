    static void WriteToFile(string sourceFile, string destinationfile, bool append = true, int bufferSize = 4096)
    {
        using (var sourceFileStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
        {
            using (var destinationFileStream = new FileStream(destinationfile, FileMode.OpenOrCreate))
            {
                while (sourceFileStream.Position < sourceFileStream.Length)
                {
                    destinationFileStream.WriteByte((byte)sourceFileStream.ReadByte());
                }
            }
        }
    }
