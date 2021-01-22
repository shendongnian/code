    public void GetStream()
    {
        // ASSUME: String URL is set to a valid URL.
        // ASSUME: String Storage is set to valid filename.
    
        Stream response = WebRequest.Create(URL).GetResponse().GetResponseStream();
        using (FileStream fs = File.Create(Storage)) 
        {
            Byte[] buffer = new Byte[32*1024];
            int read = response.Read(buffer,0,buffer.Length);
            while (read > 0)
            {
                fs.Write(buffer,0,read);
                read = response.Read(buffer,0,buffer.Length);
            }
        }
        // NOTE: Various Flush and Close of streams and storage not shown here.
    }
