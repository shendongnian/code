    private static void AppendData(string filename, int intData, string stringData, byte[] lotsOfData)
    {
        using (Stream fileStream = File.OpenWrite(filename))
        {
            using (BinaryWriter bw = new BinaryWriter(fileStream))
            {
                bw.BaseStream.Seek(0, SeekOrigin.End);
                bw.Write(intData);
                bw.Write(stringData);
                bw.Write(lotsOfData);
            }
        }
    }
