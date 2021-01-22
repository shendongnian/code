    public static XmlDocument JsonToXml(string json)
        {
            XmlNode newNode = null;
            XmlNode appendToNode = null;
            XmlDocument returnXmlDoc = new XmlDocument();
            returnXmlDoc.LoadXml("<Document />");
            XmlNode rootNode = returnXmlDoc.SelectSingleNode("Document");
            appendToNode = rootNode;
            string[] arrElementData;
            string[] arrElements = json.Split('\r');
            foreach (string element in arrElements)
            {
                string processElement = element.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                if ((processElement.IndexOf("}") > -1 || processElement.IndexOf("]") > -1) &&
                    appendToNode != rootNode)
                {
                    appendToNode = appendToNode.ParentNode;
                }
                else if (processElement.IndexOf("[") > -1)
                {
                    processElement = processElement.Replace(":", "").Replace("[", "").Replace("\"", "").Trim();
                    newNode = returnXmlDoc.CreateElement(processElement);
                    appendToNode.AppendChild(newNode);
                    appendToNode = newNode;
                }
                else if (processElement.IndexOf("{") > -1 && processElement.IndexOf(":") > -1)
                {
                    processElement = processElement.Replace(":", "").Replace("{", "").Replace("\"", "").Trim();
                    newNode = returnXmlDoc.CreateElement(processElement);
                    appendToNode.AppendChild(newNode);
                    appendToNode = newNode;
                }
                else
                {
                    if (processElement.IndexOf(":") > -1)
                    {
                        arrElementData = processElement.Replace(": \"", ":").Replace("\",", "").Replace("\"", "").Split(':');
                        newNode = returnXmlDoc.CreateElement(arrElementData[0]);
                        for (int i = 1; i < arrElementData.Length; i++)
                        { newNode.InnerText += arrElementData[i]; }
                        appendToNode.AppendChild(newNode);
                    }
                }
            }
            return returnXmlDoc;
        }
