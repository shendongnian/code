    public class MyImage : IXmlSerializable
    {
        public string Name  { get; set; }
        public Bitmap Image { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Name");
            writer.WriteString(this.Name);
            writer.WriteEndElement();
            using(MemoryStream ms = new MemoryStream())
            {
                this.Image.Save(ms, ImageFormat.Bmp );
                byte[] bitmapData = ms.ToArray();
                writer.WriteStartElement("Image");
                writer.WriteBase64(bitmapData, 0, bitmapData.Length);
                writer.WriteEndElement();
            }
        }
    }
