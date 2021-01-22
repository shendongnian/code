        Apple obj = new Apple { Variety = "Cox", Weight = 12.1M};
        XmlSerializer ser = new XmlSerializer(typeof(Apple));
        StringWriter sw = new StringWriter();
        ser.Serialize(sw, obj);
        string xml = sw.ToString();
        StringReader sr = new StringReader(xml);
        Apple obj2 = (Apple)ser.Deserialize(sr);
