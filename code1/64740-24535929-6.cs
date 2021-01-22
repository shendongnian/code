        public static string ReadAllTextFromDocx(FileInfo fileInfo)
        {
            StringBuilder stringBuilder;
            using(WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(dataSourceFileInfo.FullName, false))
            {
                NameTable nameTable = new NameTable();
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
                xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
                string wordprocessingDocumentText;
                using(StreamReader streamReader = new StreamReader(wordprocessingDocument.MainDocumentPart.GetStream()))
                {
                    wordprocessingDocumentText = streamReader.ReadToEnd();
                }
                stringBuilder = new StringBuilder(wordprocessingDocumentText.Length);
                XmlDocument xmlDocument = new XmlDocument(nameTable);
                xmlDocument.LoadXml(wordprocessingDocumentText);
                XmlNodeList paragraphNodes = xmlDocument.SelectNodes("//w:p", xmlNamespaceManager);
                foreach(XmlNode paragraphNode in paragraphNodes)
                {
                    XmlNodeList textNodes = paragraphNode.SelectNodes(".//w:t | .//w:tab | .//w:br", xmlNamespaceManager);
                    foreach(XmlNode textNode in textNodes)
                    {
                        switch(textNode.Name)
                        {
                            case "w:t":
                                stringBuilder.Append(textNode.InnerText);
                                break;
                            case "w:tab":
                                stringBuilder.Append("\t");
                                break;
                            case "w:br":
                                stringBuilder.Append("\v");
                                break;
                        }
                    }
                    stringBuilder.Append(Environment.NewLine);
                }
            }
            return stringBuilder.ToString();
        }
