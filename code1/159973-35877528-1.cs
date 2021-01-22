    using(var inputReader = new SegmentingReader(/*TextReader from somewhere */))
    using(var serializer = new XmlSerializer(typeof(SerializedClass)))
    while (inputReader.Peek() != -1)
    {
        using (var xmlReader = XmlReader.Create(inputReader)) {
            xmlReader.MoveToContent();
            var obj = serializer.Deserialize(xmlReader.ReadSubtree());
            DoStuff(obj);
        }
    }
