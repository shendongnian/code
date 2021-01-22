    private static void AppendData(string filename, int intData, string stringData, byte[] lotsOfData)
    {
        using (var fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.None))
        using (var bw = new BinaryWriter(fileStream))
        {
            bw.Write(intData);
            bw.Write(stringData);
            bw.Write(lotsOfData);
        }
    }
