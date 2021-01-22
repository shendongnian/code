    byte[] data;
        
    using (System.IO.FileStream stream = new System.IO.FileStream("path", System.IO.FileMode.Open))
    {
        data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
    }
