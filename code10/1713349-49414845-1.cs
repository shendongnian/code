    public static void WriteXML(int day, double[] mess, string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        var messwert = (from XmlElement element in doc.GetElementsByTagName("messwert")
                        where element.SelectSingleNode("tag").InnerText == day.ToString()
                        select element).FirstOrDefault();
        if(messwert == null)
        {
            throw new ArgumentException($"The day value, doesn't exist.  the value passed is {day}");
        }
        var nieder = messwert.SelectSingleNode("niederschlag");
        if (nieder != null)
        {
            nieder.InnerText = mess[0].ToString();
        }
        doc.Save(path);
    }
