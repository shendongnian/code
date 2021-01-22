    public static DownloadableFile ToDownloadableXmlFileForExcel2003(this System.Xml.Linq.XDocument file, string fileName)
    {
        byte[] buffer = UTF8Encoding.UTF8.GetBytes(String.Format("<?xml version=\"1.0\"?>{0}", file)); //<?xml version=\"1.0\"?> somehow disapears so we need to inject it.
        
        DownloadableFile dbf =
            new DownloadableFile
            {
                FileName = String.Format("{0}.xls", fileName.Replace(" ", "")),
                Content =  buffer,
                MimeType = "application/vnd.ms-excel"
            };
        return dbf;
    }
