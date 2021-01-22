    var yourList = new List<int>() { 1, 2, 3 };
    using (StringWriter sw = new StringWriter())
    {
        var xs = new XmlSerializer(yourList.GetType());
        xs.Serialize(sw, yourList);
        string xmlEncodedList = sw.ToString();
    }
