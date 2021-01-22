    public class XmlTextWriterFull : XmlTextWriter
    {
        public XmlTextWriterFull(TextWriter sink) : base(sink) { }
        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }
    ...
    var writer = new XmlTextWriterFull(innerwriter);
    serializer.Serialize(writer, obj);
