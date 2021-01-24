    private static void GenerateXml()
    {
            List<DriveData> DiskDrives = new List<DriveData>();
            DiskDrives.Add(new DriveData() { Model = "model1", Type = "type1", SizeGB = 10, SerialNumber = "20155", IsOK = false });
            DiskDrives.Add(new DriveData() { Model = "model2", Type = "type2", SizeGB = 20, SerialNumber = "20165", IsOK = true });
            var newDoc = new XDocument(new XDeclaration("1.0", null, "yes"));
            XElement xmlElements = new XElement("HardDrives",
                from item in DiskDrives
                select new XElement("HardDrive",
                    new XElement("Model", item.Model),
                    new XElement("Type", item.Type),
                    new XElement("SizeGB", item.SizeGB),
                    new XElement("SerialNumber", item.SerialNumber),
                    new XElement("IsOK", item.IsOK)));
            newDoc.Add(xmlElements);
            newDoc.Save(@"C:\sample.xml");
    }
