    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml1 = 
                 "<SecurityPrivileges>" +
                   "<SecurityPrivilege Principal=\"Jack Smith\">" +
                      "<Privilege Type=\"FileSystem\" AccessType=\"read\">c:\\log</Privilege>" +
                      "<Privilege Type=\"FileSystem\" AccessType=\"write\">c:\\log</Privilege>" +
                   "</SecurityPrivilege>" +
                "</SecurityPrivileges>";
                string xml2 =
                 "<SecurityPrivileges>" +
                   "<SecurityPrivilege Principal=\"Jack Smith\">" +
                      "<Privilege Type=\"FileSystem\" AccessType=\"write\">c:\\log</Privilege>" +
                   "</SecurityPrivilege>" +
                "</SecurityPrivileges>";
                XDocument doc1 = XDocument.Parse(xml1);
                XElement securityPrivilege1 = doc1.Descendants("SecurityPrivilege").FirstOrDefault();
                XDocument doc2 = XDocument.Parse(xml2);
                XElement securityPrivilege2 = doc2.Descendants("SecurityPrivilege").FirstOrDefault();
                List<XElement> children = securityPrivilege1.Elements().ToList();
                children.AddRange(securityPrivilege2.Elements().ToList());
                var childs = children.Select(x => new { element = x, attributes = x.Attributes().Select(y => new KeyValuePair<string, string>(y.Name.LocalName, (string)y)).OrderBy(z => z.Key).ToList() }).ToList();
                var groups = childs.GroupBy(x => new KeyValuePairCompare() { values = x.attributes }).ToList();
                securityPrivilege1.ReplaceNodes(groups.Select(x => x.FirstOrDefault().element));
            }
        }
        public class KeyValuePairCompare : IEquatable<KeyValuePairCompare>
        {
            public List<KeyValuePair<string, string>> values { get; set; }
            public Boolean Equals(KeyValuePairCompare other)
            {
                Boolean match = (values.Count == other.values.Count) && values.Select((x, i) => new { x = x, i = i }).All(x => (x.x.Key == other.values[x.i].Key) && (x.x.Value == other.values[x.i].Value)); 
                return match;
            }
            public override int GetHashCode()
            {
                return 1;
            }
        }
    }
