        public static XAttribute GetMetadata(this XElement parent, string key)
        {
            return parent.Elements("metadata").Elements("dc")
                     .FirstOrDefault(x => x.Attribute("element").Value == key)
                     .Attribute("value");
        }
