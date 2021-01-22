    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    namespace Extenders
    {
        public static class StringExtender
        {
            internal static void ParseHtmlDocument(XmlDocument doc, XmlNode root, string[] allowedTags, string[] allowedAttributes, string[] allowedStyleKeys)
            {
                XmlNodeList nodes;
    
                if (root == null) root = doc.ChildNodes[0];
                nodes = root.ChildNodes;
    
                foreach (XmlNode node in nodes)
                {
                    if (!(allowedTags.Any(x => x.ToLower() == node.Name.ToLower())))
                    {
                        var safeNode = doc.CreateTextNode(node.InnerText);
                        root.ReplaceChild(safeNode, node);
                    }
                    else
                    {
                        if (node.Attributes != null)
                        {
                            var attrList = node.Attributes.OfType<XmlAttribute>().ToList();
                            foreach (XmlAttribute attr in attrList)
                            {
                                if (!(allowedAttributes.Any(x => x.ToLower() == attr.Name)))
                                {
                                    node.Attributes.Remove(attr);
                                }
                                // TODO: if style is allowed, check the allowed keys: values
                            }
                        }
                    }
    
                    if (node.ChildNodes.Count > 0)
                        ParseHtmlDocument(doc, node, allowedTags, allowedAttributes, allowedStyleKeys);
                }
            }
    
            public static string ParseSafeHtml(this string input, string[] allowedTags, string[] allowedAttributes, string[] allowedStyleKeys)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<span>" + input + "</span>");
    
                ParseHtmlDocument(xmlDoc, null, allowedTags, allowedAttributes, allowedStyleKeys);
    
                string result;
    
                using (var sw = new StringWriter())
                {
                    using (var xw = new XmlTextWriter(sw))
                        xmlDoc.WriteTo(xw);
    
                    result = sw.ToString();
                }
    
                return result.Substring(6, result.Length - 7);
            }
        }
    }
