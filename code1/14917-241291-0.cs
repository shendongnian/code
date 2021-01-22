    using System;
    using System.Text;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            string xml = @"
    <root>
      <foo />
      <foo>
         <bar attr='value'/>
         <bar other='va' />
      </foo>
      <foo><bar /></foo>
    </root>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode node = doc.SelectSingleNode("//@attr");
            Console.WriteLine(FindXPath(node));
            Console.WriteLine(doc.SelectSingleNode(FindXPath(node)) == node);
        }
        
        static string FindXPath(XmlNode node)
        {
            StringBuilder builder = new StringBuilder();
            while (node != null)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Attribute:
                        builder.Insert(0, "/@" + node.Name);
                        node = ((XmlAttribute) node).OwnerElement;
                        break;
                    case XmlNodeType.Element:
                        int index = FindElementIndex((XmlElement) node);
                        builder.Insert(0, "/" + node.Name + "[" + index + "]");
                        node = node.ParentNode;
                        break;
                    case XmlNodeType.Document:
                        return builder.ToString();
                    default:
                        throw new ArgumentException("Only elements and attributes are supported");
                }
            }
            throw new ArgumentException("Node was not in a document");
        }
        
        static int FindElementIndex(XmlElement element)
        {
            XmlNode parentNode = element.ParentNode;
            if (parentNode is XmlDocument)
            {
                return 1;
            }
            XmlElement parent = (XmlElement) parentNode;
            int index = 1;
            foreach (XmlElement candidate in parent.GetElementsByTagName(element.Name))
            {
                if (candidate == element)
                {
                    return index;
                }
                index++;
            }
            throw new ArgumentException("Couldn't find element within parent");
        }
    }
