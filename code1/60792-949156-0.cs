    class Program {
        static void Main(string[] args) {
            XmlDocument d = new XmlDocument();
            
            XmlNode root = d.CreateNode(XmlNodeType.Element, "root", null);
            d.AppendChild(root);
            XmlNode cdata = d.CreateNode(XmlNodeType.CDATA, "cdata", null);
            cdata.InnerText = "some <b>bolded</b> text";
            root.AppendChild(cdata);
            PrintDocument(d);
        }
        private static void PrintDocument(XmlDocument d) {
            StringWriter sw = new StringWriter();
            XmlTextWriter textWriter = new XmlTextWriter(sw);
            d.WriteTo(textWriter);
            Console.WriteLine(sw.GetStringBuilder().ToString());
        }
    }
