        public void WriteXml(XmlWriter writer)
        {
            foreach (var p in GetType().GetProperties())
            {
                if (p.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Any())
                    continue;
                var value = p.GetValue(this, null);
                if (value != null)
                {
                    writer.WriteStartElement(p.Name);
                    writer.WriteValue(value);
                    writer.WriteEndElement();
                }
            }
        }
