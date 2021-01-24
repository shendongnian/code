    void Main()
    {
        string mainFolder = "StackOverflow";
        string wholesaleFolder = "Test";
        string wholesalePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), mainFolder, wholesaleFolder);
    
        wholesalePath = Path.Combine(wholesalePath, fileName);
    
        Directory.CreateDirectory(wholesalePath);
        string fileName = "xmltest.xml";
        XmlDocument doc = new XmlDocument();
        string oneLine = "<root></root>";
        doc.Load(new StringReader(oneLine));
        doc.Save(wholesalePath);
    }
