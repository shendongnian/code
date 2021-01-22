    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Xml;
    using System.Text;
    using System.IO.Compression;
    public static class DocxTextExtractor
    {
        public static string Extract(string filename)
        {
            XmlNamespaceManager NsMgr = new XmlNamespaceManager(new NameTable());
            NsMgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            using (var archive = ZipFile.OpenRead(filename))
            {
                return XDocument
                    .Load(archive.GetEntry(@"word/document.xml").Open())
                    .XPathSelectElements("//w:p", NsMgr)
                    .Aggregate(new StringBuilder(), (sb, p) => p
                        .XPathSelectElements(".//w:t|.//w:tab|.//w:br", NsMgr)
                        .Select(e => { switch (e.Name.LocalName) { case "br": return "\v"; case "tab": return "\t"; } return e.Value; })
                        .Aggregate(sb, (sb1, v) => sb1.Append(v)))
                    .ToString();
            }
        }
    }
