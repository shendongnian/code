    using System.Xml;
    using System.Xml.Linq;
    
    class Program {
        static void Main() {
            var xDocument = new XDocument(
                new XDocumentType("html", null, null, null),
                new XElement("html",
                    new XElement("head"),
                    new XElement("body",
                        new XElement("p",
                            "This paragraph contains ", new XElement("b", "bold"), " text."
                        ),
                        new XElement("p",
                            "This paragraph has just plain text."
                        )
                    )
                )
            );
    
            var settings = new XmlWriterSettings {
                OmitXmlDeclaration = true, Indent = true, IndentChars = "\t"
            };
            using (var writer = XmlWriter.Create(@"C:\Users\wolf\Desktop\test.html", settings)) {
                xDocument.WriteTo(writer);
            }
        }
    }
