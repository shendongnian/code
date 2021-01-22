     public class CustomXmlDocument : XmlDocument
        {
            public string CustomBaseURL { get; set; }
    
    
            public override string BaseURI
            {
                get { return this.CustomBaseURL; }
            }
        }
    
    CustomXmlDocument objXML=new CustomXmlDocument();
    objXML.CustomBaseURL="BaseURI";
    objXML.loadXml(xml document);
