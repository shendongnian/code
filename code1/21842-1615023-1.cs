        public static void AttachXmlAttributes(XmlAttributeOverrides xao, Type t)
        {
            List<Type> types = new List<Type>();
            AttachXmlAttributes(xao, types, t);
        }
        public static void AttachXmlAttributes(XmlAttributeOverrides xao, List<Type> all, Type t)
        {
            if(all.Contains(t))
                return;
            else
                all.Add(t);
            XmlAttributes list1 = GetAttributeList(t.GetCustomAttributes(false));
            xao.Add(t, list1);
            
            foreach (var prop in t.GetProperties())
            {
                XmlAttributes list2 = GetAttributeList(prop.GetCustomAttributes(false));
                xao.Add(t, prop.Name, list2);
                AttachXmlAttributes(xao, all, prop.PropertyType);
            }
        }
        private static XmlAttributes GetAttributeList(object[] attributes)
        {
            XmlAttributes list = new XmlAttributes();
            foreach (var attribute in attributes)
            {
                Type type = attribute.GetType();
                if (type.Name == "XmlAttributeAttribute") list.XmlAttribute = (XmlAttributeAttribute)attribute;
                else if (type.Name == "XmlArrayAttribute") list.XmlArray = (XmlArrayAttribute)attribute;
                else if (type.Name == "XmlArrayItemAttribute") list.XmlArrayItems.Add((XmlArrayItemAttribute)attribute);
            }
            return list;
        }
        public static string GetSchema<T>()
        {
            XmlAttributeOverrides xao = new XmlAttributeOverrides();
            AttachXmlAttributes(xao, typeof(T));
            XmlReflectionImporter importer = new XmlReflectionImporter(xao);
            XmlSchemas schemas = new XmlSchemas();
            XmlSchemaExporter exporter = new XmlSchemaExporter(schemas);
            XmlTypeMapping map = importer.ImportTypeMapping(typeof(T));
            exporter.ExportTypeMapping(map);
            using (MemoryStream ms = new MemoryStream())
            {
                schemas[0].Write(ms);
                ms.Position = 0;
                return new StreamReader(ms).ReadToEnd();
            }
        }
