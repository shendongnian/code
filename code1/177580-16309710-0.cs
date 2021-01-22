        private string poco2Xml(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            StringBuilder result = new StringBuilder();
            using (var writer = XmlWriter.Create(result))
            {
                serializer.Serialize(writer, obj);
            }
            return result.ToString();
        }
