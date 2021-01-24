    public static string GetElementByName(string responseContent, string classification, string attributeName, string attributeValue)
    {
        string result = "";
        XmlTextReader textReader = new XmlTextReader(new System.IO.StringReader(responseContent));
        while (textReader.Read())
        {
            switch (textReader.NodeType)
            {
                case XmlNodeType.Element:
                    if (!textReader.IsEmptyElement)
                    {
                        if (textReader.Name == "Classification" && textReader.GetAttribute("ClassificationType") == classification)
                        {
                            textReader.ReadToNextSibling("Reference");
                            if (textReader.GetAttribute(attributeName) == attributeValue)
                            {
                                result = textReader.ReadInnerXml();
                            }
                        }
                    }
                    break;
                case XmlNodeType.Text:
                    break;
                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                    break;
                case XmlNodeType.Comment:
                    break;
                case XmlNodeType.EndElement:
                    break;
            }
        }
        return result;
    }
