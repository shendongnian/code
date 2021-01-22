    [WebMethod]
    public bool Write(String fileName, Byte[] data)
    {
        FileStream  fs = File.Open(fileName, FileMode.Open);
        BinaryWriter bw = new BinaryWriter(fs); 
        bw.Write(data);
        bw.Close();
    
        return true;
    }
