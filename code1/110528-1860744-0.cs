public class FullEndingXmlTextWriter : XmlTextWriter
{
    public FullEndingXmlTextWriter(TextWriter w)
        : base(w)
    {
    }
    public FullEndingXmlTextWriter(Stream w, Encoding encoding)
        : base(w, encoding)
    {
    }
    public FullEndingXmlTextWriter(string fileName, Encoding encoding)
        : base(fileName, encoding)
    {
    }
    public override void WriteEndElement()
    {
        this.WriteFullEndElement();
    }
}
