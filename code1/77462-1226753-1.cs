    public class MyClass : IXmlSerializable
    {
        public MyObject MyObjectProperty;
    
        public void WriteXml (XmlWriter writer)
        {
            //open the two layers
            //serialize MyObject
            //close the two layers
        }
    
        public void ReadXml (XmlReader reader)
        {
            //read all the layers back, etc
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    
    }
