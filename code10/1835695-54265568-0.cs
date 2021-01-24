     XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList elemList = doc.GetElementsByTagName("setting");
                for (int i = 0; i < elemList.Count; i++)
                {
                    if (elemList[i].Attributes["name"].Value == "UserName")
                    {
                        textBox1.Text += elemList[i].InnerText;
                    }
                }
