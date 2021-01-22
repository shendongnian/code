    using System.Xml.Serialization;
    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlRoot(Namespace="https://foo.com/services/schema/1.2/car_quote")]
    public partial class request
    {
        get 
        {
            [XmlNamespaceDeclarations()]
            public XmlSerializerNamespaces xmlsn
            {
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("quote", "https://foo.com/services/schema/1.2/car_quote");
                return xsn;
            }
        } 
        set { }
    }
