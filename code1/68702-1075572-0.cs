        public static string HtmlReformat(string html)
        {
            var sw = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
            XmlReader rdr = XmlReader.Create(new StringReader(html));
            while (rdr.Read())
            {
                switch (rdr.NodeType)
                {
                    case XmlNodeType.EndElement:
                        htmlWriter.WriteEndTag(rdr.Name);
                        htmlWriter.Write(System.Environment.NewLine);
                        break;
                    case XmlNodeType.Element:
                            htmlWriter.WriteBeginTag(rdr.Name);
                            for (int attributeIdx = 0; attributeIdx < rdr.AttributeCount; attributeIdx++)
                            {
                                    string attribName = rdr.GetAttribute(attributeIdx);
                                    htmlWriter.WriteAttribute(rdr.Name, attribName);
                            }
                            htmlWriter.Write(">");
                            htmlWriter.Write(System.Environment.NewLine);
                            break;
                    case XmlNodeType.Text:
                        htmlWriter.Write(rdr.Value);
                        break; 
                    default:
                        throw new NotImplementedException("Handle " + rdr.NodeType);
                }
 
            }
            return sw.ToString();
        }
