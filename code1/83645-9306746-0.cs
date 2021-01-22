        public static XElement ToXML(this object o)
        {
            Type t = o.GetType();
            Type[] extraTypes = t.GetProperties()
                .Where(p => p.PropertyType.IsInterface)
                .Select(p => p.GetValue(o, null).GetType())
                .ToArray();
            DataContractSerializer serializer = new DataContractSerializer(t, extraTypes);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            serializer.WriteObject(xw, o);
            return XElement.Parse(sw.ToString());
        }
