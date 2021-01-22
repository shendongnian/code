    public class DTO
    {
        [XmlIgnore]
        public string additionalInformation;
        [XmlElement(Order=1)]
        public DateTime stamp;
        
        [XmlElement(Order=2)]
        public string name;
        
        [XmlElement(Order=3)]
        public double value;
        
        [XmlElement(Order=4)]
        public int index;
    }
    
    public class OverridesDemo
    { 
        public void Run()
        {
            DTO dto = new DTO
                {
                    additionalInformation = "This will bbe serialized separately",
                    stamp = DateTime.UtcNow,
                    name = "Marley",
                    value = 72.34,
                    index = 7
                };
            // ---------------------------------------------------------------
            // 1. serialize normally
            // this will allow us to omit the xmlns:xsi namespace
            var ns = new XmlSerializerNamespaces();
            ns.Add( "", "" );
            XmlSerializer s1 = new XmlSerializer(typeof(DTO));
            var builder = new System.Text.StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent= true };
            Console.WriteLine("\nSerialize using the in-line attributes: ");
            using ( XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                s1.Serialize(writer, dto, ns);
            }
            Console.WriteLine("{0}",builder.ToString());
            Console.WriteLine("\n");            
            // ---------------------------------------------------------------
            // ---------------------------------------------------------------
            // 2. serialize with attribute overrides
            // use a non-empty default namespace
            ns = new XmlSerializerNamespaces();
            string myns = "urn:www.example.org";
            ns.Add( "", myns);
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            
            XmlAttributes attrs = new XmlAttributes();
            // override the (implicit) XmlRoot attribute
            XmlRootAttribute attr1 = new XmlRootAttribute
                {
                    Namespace = myns,
                    ElementName = "DTO-Annotations",
                };
            attrs.XmlRoot = attr1;
            overrides.Add(typeof(DTO), attrs);
            // "un-ignore" the first property
            // define an XmlElement attribute, for a type of "String", with no namespace
            var a2 = new XmlElementAttribute(typeof(String)) { ElementName="note", Namespace = myns };
            // add that XmlElement attribute to the 2nd bunch of attributes
            attrs = new XmlAttributes();
            attrs.XmlElements.Add(a2);
            attrs.XmlIgnore = false; 
            
            // add that bunch of attributes to the container for the type, and
            // specifically apply that bunch to the "additionalInformation" property 
            // on the type.
            overrides.Add(typeof(DTO), "additionalInformation", attrs);
            // now, XmlIgnore all the other properties
            attrs = new XmlAttributes();
            attrs.XmlIgnore = true;       
            overrides.Add(typeof(DTO), "stamp", attrs);
            overrides.Add(typeof(DTO), "name",  attrs);
            overrides.Add(typeof(DTO), "value", attrs);
            overrides.Add(typeof(DTO), "index", attrs);
            
            // create a serializer using those xml attribute overrides
            XmlSerializer s2 = new XmlSerializer(typeof(DTO), overrides);
            Console.WriteLine("\nSerialize using the override attributes: ");
            builder.Length = 0;
            using ( XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                s2.Serialize(writer, dto, ns);
            }
            Console.WriteLine("{0}",builder.ToString());
            Console.WriteLine("\n");            
            // ---------------------------------------------------------------
        }
    }
