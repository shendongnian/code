    public InputXmlModel GetInputXmlModelByXmlFile(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Article));
        using (FileStream fileStream = new FileStream("<PathToFile>", FileMode.Open))
        {
            Article result = (Article)serializer.Deserialize(fileStream);
        }
    }
