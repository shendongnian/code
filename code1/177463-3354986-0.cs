    static public byte[] GetBytesFromUrl(string url)
    {
        byte[] b;
        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
        WebResponse myResp = myReq.GetResponse();
    
        Stream stream = myResp.GetResponseStream();
        //int i;
        using (BinaryReader br = new BinaryReader(stream))
        {
            //i = (int)(stream.Length);
            b = br.ReadBytes(500000);
            br.Close();
        }
        myResp.Close();
        return b;
    }
    static public void WriteBytesToFile(string fileName, byte[] content)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create);
        BinaryWriter w = new BinaryWriter(fs);
        try
        {
            w.Write(content);
        }
        finally
        {
            fs.Close();
            w.Close();
        }
    }
