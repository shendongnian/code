    public List<XDocument> createTemporaryXMLFiles(string pathToData, int batchSize)
    {
        List<XDocument> batchRechnungen = new List<XDocument>();
        XElement dataSource = XElement.Load(pathToData);            
        XDocument batchRechnung = new XDocument(new XElement(dataSource.Name));
        var rechnungen = dataSource.Elements().ToArray();
        for (int i = 0; i < rechnungen.Length; i++)
        {
            if (i == 0 || (i % batchSize) == 0)
            {
                batchRechnung = new XDocument(new XElement(dataSource.Name));
                batchRechnungen.Add(batchRechnung);
            }
            batchRechnung.Root.Add(rechnungen[i]);
        }
        return batchRechnungen;
    }
