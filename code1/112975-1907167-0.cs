    public class BitmapContainer : IXmlSerializable
    {
        public BitmapContainer() { }
    
        public Bitmap Data { get; set; }
    
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
    
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
    
    public class TypeWithBitmap
    {
        public BitmapContainer MyImage { get; set; }
    
        public string Name { get; set; }
    }
