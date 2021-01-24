    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    {
        var serializer = new XmlSerializer(typeof(A));
        Encoding utf8EncodingWithNoByteOrderMark = new UTF8Encoding(false);
        XmlTextWriter xtw = new XmlTextWriter(memoryStream, utf8EncodingWithNoByteOrderMark);
        serializer.Serialize(xtw, new A());
        string xml = Encoding.UTF8.GetString(memoryStream.ToArray());
        Log.Error("lv", xml[0]+"");
    }
