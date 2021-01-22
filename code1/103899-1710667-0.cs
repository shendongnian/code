        string listXml = Serialize<List<A>>(ListA, new Type[] { typeof(B), typeof(C) });
        List<IA> NewList = Deserialize<List<A>>(listXml, new Type[] { typeof(B), typeof(C) });
        private static T Deserialize<T>(string Xml, Type[] KnownTypes)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T),KnownTypes);
            StringReader sr = new StringReader(Xml);
            return (T)xs.Deserialize(sr);
        }
        private static string Serialize<T>(Object obj, Type[] KnownTypes)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T), KnownTypes);
                
                xs.Serialize(sw, obj);
            }
            return sb.ToString();
        }
