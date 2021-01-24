            private void main()
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"C:\test.xml");
                XmlNode root = xDoc.SelectSingleNode("*");
                checkDown(root);            
            }
            private void checkDown(XmlNode root)
            {
                if (root.HasChildNodes)
                    checkDown(root.FirstChild);
                else
                {
                    string str = "";
                    checkUp(root, ref str);
                    List1.Add(str);
                }
                if (root.NextSibling != null)
                    checkDown(root.NextSibling);
            }
            private void checkUp(XmlNode root, ref string str)
            {
                if (root.Attributes != null)
                    if (root.Attributes["code"] != null)
                    {
                        checkPrev(root, getAttribute(root));
                        if (counter > 0)
                        {
                            str = String.Concat("/", getAttribute(root), "[", (counter + 1).ToString(), "]") + str;
                            counter = 0;
                        }
                        else
                            str = "/" + root.Attributes["code"].Value.ToString() + str;
                    }
    
                if (root.ParentNode != null)
                    checkUp(root.ParentNode, ref str);
            }
            void checkPrev(XmlNode root, string stext)
            {
                if (root.PreviousSibling != null)
                {
                    if (getAttribute(root.PreviousSibling) == stext)
                    {
                        counter++;
                        checkPrev(root.PreviousSibling, stext);
                    }
                }
            }
            private string getAttribute(XmlNode root)
            {
                if (root.Attributes != null)
                    if (root.Attributes["code"] != null)
                        return root.Attributes["code"].Value.ToString();
                return null;
            }
