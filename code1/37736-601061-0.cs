    public void UploadFile(string srcUrl, string destUrl)
    {
        if (! File.Exists(srcUrl))
        {
            throw new ArgumentException(String.Format("{0} does not exist", 
                srcUrl), "srcUrl");
        }
    
        SPWeb site = new SPSite(destUrl).OpenWeb();
    
        FileStream fStream = File.OpenRead(srcUrl);
        byte[] contents = new byte[fStream.Length];
        fStream.Read(contents, 0, (int)fStream.Length);
        fStream.Close(); 
    
        EnsureParentFolder(site, destUrl);
        site.Files.Add(destUrl, contents);
    }
