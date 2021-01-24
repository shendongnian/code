        public string ReadResourceComment(XmlDocument doc, string FieldName)
        {
            if (doc != null && !string.IsNullOrEmpty(doc.InnerXml))
            {
                return doc.SelectSingleNode("root/data[@name='" + FieldName + "']")["comment"].InnerText;
            }
            return string.Empty;
        }
