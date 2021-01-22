       XmlDocument doc;
                    XmlElement root;
                    XmlElement rootnode;
                    XmlElement Login;
                    if (File.Exists(@"C:\Test.xml") == false)
                    {
                        doc = new XmlDocument();
                        root = doc.CreateElement("LicenseDetails");
        
                        rootnode = doc.CreateElement("License");
                        Login = doc.CreateElement("Login_Name");
                        Login.InnerText = "KSC";
                        rootnode.AppendChild(Login);
                        root.AppendChild(rootnode);
                        doc.AppendChild(root);
                      
    
      doc.Save(@"C:\Test.xml");
                }
