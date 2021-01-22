    class TopClass
    {
        InnerClass _innerClass = new InnerClass();
        public void Serialize(Stream stream)
        {
            XmlWriter xmlWriter = XmlWriterExt.GetWriter(stream);
            xmlWriter.WriteStartElement("top");
            xmlWriter.PrepareStream(stream);
            _innerClass.Serialize(stream);
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
        }
    }
    class InnerClass
    {
        public void Serialize(Stream stream)
        {
            XmlWriter xmlWriter = XmlWriterExt.GetWriter(stream);
            xmlWriter.WriteElementString("b", "testing");
            xmlWriter.Flush();
        }
    }
