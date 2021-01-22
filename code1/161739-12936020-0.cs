        private static string Escape(string content)
        {
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings 
            { 
                ConformanceLevel = ConformanceLevel.Fragment 
            };
            using (var xmlWriter = XmlWriter.Create(sb, settings))
                xmlWriter.WriteString(content);
                
            return sb.ToString();
        }
