    using (var reader = XmlReader.Create("test.xml"))
    {
        XNamespace ns = "http://www.netapp.com/schemas/ONTAP/2007/AuditLog";
        while (reader.ReadToFollowing("EventData"))
        {
            var eventData = (XElement)XElement.ReadFrom(reader);
            var data = eventData.Elements(ns + "Data")
                .FirstOrDefault(e => e.Attribute("Name").Value == "InformationSet");
            if (data != null && data.Value.Contains("Delete on last close"))
            {
                // use eventData somehow
                Console.WriteLine(eventData);
            }
        }
    }
