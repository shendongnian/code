    string zipPath = @".\result.zip";
    var listResults = new List<myType>();
    
    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
    {
        foreach (
            ZipArchiveEntry entry in 
            archive.Entries.Where(e=> .FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
        )
        {
            XmlSerializer serializer = new XmlSerializer(typeof(myType);
            listResults.Add((myType)serializer.Deserialize(readmeEntry.Open()));
        }
    }
