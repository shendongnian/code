        public static XmlElement Serialize(MyObject someClassInstance)
        {            
            XmlSerializer serializer = new XmlSerializer(typeof(MyObject));
            XmlDocument doc = new XmlDocument();
            
            XPathNavigator nav = doc.CreateNavigator();
            XmlWriter writer = nav.AppendChild();
            serializer.Serialize(writer, someClassInstance);
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            return doc.DocumentElement;
        }
