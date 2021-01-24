    public static void WriteXML(int day, double[] mess, string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        var nieder = (from XmlElement element in doc.GetElementsByTagName("messwert")
                             where element.SelectSingleNode("tag").InnerText == day.ToString()
                             select element).First().SelectSingleNode("niederschlag");
        if (nieder != null)
        {
            nieder.InnerText = mess[0].ToString();
        }
        doc.Save(path);
    }
