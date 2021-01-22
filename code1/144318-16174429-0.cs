            XmlSerializer x = new XmlSerializer(msg.GetType());
            StringWriter sw = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            x.Serialize(sw, msg, namespaces);
            string s = sw.ToString();
            sw.Close();
