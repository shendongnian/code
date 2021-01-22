     XmlDocument doc =  new XmlDocument();
            doc.Load("PathTo.xml");
            User obj;
            using (TextReader textReader = new StringReader(doc.OuterXml))
            {
                using (XmlTextReader reader = new XmlTextReader(textReader))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(User));
                    obj = (User)serializer.Deserialize(reader);
                }
            }
