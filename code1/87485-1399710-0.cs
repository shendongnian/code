    public static string SerializeExplicit(SomeObject obj)
    {    
        XmlWriterSettings settings;
        settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
    
        XmlSerializerNamespaces ns;
        ns = new XmlSerializerNamespaces();
        ns.Add("", "");
    
    
        XmlSerializer serializer;
        serializer = new XmlSerializer(typeof(SomeObject));
    
        //Or, you can pass a stream in to this function and serialize to it.
        // or a file, or whatever - this just returns the string for demo purposes.
        StringBuilder sb = new StringBuilder();
        usint(var xwriter = XmlWriter.Create(sb, settings))
        {
    
            serializer.Serialize(xwriter, obj, ns);
            return sb.ToString();
        }
    }
