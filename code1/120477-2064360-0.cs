        public static void SerializeToXmlFile(object obj, Type type, string fileName, string xsltPath) {
            var ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);
            var serializer = new XmlSerializer(type);
            var settings = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
            StringBuilder sb = new StringBuilder();
            using (var w = XmlWriter.Create(sb, settings)) {
                if (!String.IsNullOrEmpty(xsltPath)) {
                    w.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"" + xsltPath + "\"");
                }
                serializer.Serialize(w, obj, ns);
            }
            File.WriteAllText(fileName, sb.ToString());
        }
