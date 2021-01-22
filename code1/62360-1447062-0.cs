    private const string XmlFileNameKey = "xmlMenuFileName";
    private const string XmlItemTag = "siteMapNode";
    private const string XmlNodeTarget = "target";
    Public MenuItem ReadXML()
    {
            MenuItem retVal = new MenuItem(null);
            XmlTextReader reader = new XmlTextReader(xmlFileLocation);
            retVal.topMost = true;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Attribute:
                        break;
                    case XmlNodeType.CDATA:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.Element:
                        if (reader.Name == XmlItemTag)
                        {
                            bool isempty = reader.IsEmptyElement;
                            
                            MenuItem temp = new MenuItem();
                            temp.topMost = false;
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    SetAttributeValue(ref temp, reader.Name, reader.Value);
                                }
                            }
                           retVal.children.Add(temp);
                            if (!isempty)
                            {
                                temp.parent = retVal;
                                 retVal = temp;    
                            }
                            
                        }
                        break;
                    case XmlNodeType.EndElement:
                       string test = reader.Name;
                       if (retVal.parent != null )
                       {
                            retVal = retVal.parent;
                       }
                       
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        break;
                }
            }
            //Close the reader
            reader.Close();
            while (retVal.parent != null && !retVal.topMost)
            {
                retVal = retVal.parent;
            }
    }
