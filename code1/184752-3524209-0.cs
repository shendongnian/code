    string xmlContent = getContentFromMyDataBase();
    var xs = new XmlSerializer(typeof(MyObj));
    using (var reader = new StringReader(xmlContent))
    {
        var theObj = (MyObj)xs.Deserialize(reader);
    }
