    public static  void SaveStream(Stream st,string targetFile)
    {
        byte[] inBuffer = new byte[10000];
            
        using(FileStream outStream=File.Create(targetFile,20000))
        using (BinaryWriter wr = new BinaryWriter(outStream))
        {
            st.Read(inBuffer, 0, inBuffer.Length);
            wr.Write(inBuffer);
        }
    }
