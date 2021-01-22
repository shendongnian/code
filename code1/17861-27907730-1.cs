    public static XDocument MergeDir(string xmlDir)
    {
        XDocument xdoc = XDocument.Parse("<root></root>");
        System.IO.DirectoryInfo directory = new DirectoryInfo(xmlDir);
        if (directory.Exists)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles())
            {
                if (file.Extension == ".xml")
                {
                    xdoc.Root.Add(XDocument.Load(file.FullName).Root.Elements());
                }
            }
        }
    
        return xdoc;
    }
