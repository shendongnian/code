    var yourList = new List<int>() { 1, 2, 3 };
    using (var stream = new MemoryStream())
    using (var writer = XmlWriter.Create(stream))
    {
        new XmlSerializer(yourList.GetType()).Serialize(writer, yourList);
        var xmlEncodedList = Encoding.UTF8.GetString(stream.ToArray());
    }
