    var yourList = new List<int>() { 1, 2, 3 };
    using (var writer = new StringWriter())
    {
        new XmlSerializer(yourList.GetType()).Serialize(writer, yourList);
        var xmlEncodedList = writer.GetStringBuilder().ToString();
    }
