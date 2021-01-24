    doc = new XmlDocument();
                string fullFileName = System.Environment.CurrentDirectory + @"\" + "Databases.xml";
                doc.Load(fullFileName);
    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.InnerText == DBName)
                    {
                        string currConnStr = Decrypt(node.Attributes["ConnStr"].Value);
                        return currConnStr;
                    }
                }
