    string uploadCode = "UploadCode";
    string LabName = "LabName";
    XElement root = new XElement("TestLabs");
    foreach (var item in returnList)
    {  
           root.Add(new XElement("TestLab",
                    new XElement(uploadCode, item.UploadCode),
                    new XElement(LabName, item.LabName)
                                )
                   );
    }
    
    XDocument returnXML = new XDocument(new XDeclaration("1.0", "UTF-8","yes"),
                 root);
    
    string returnVal;
    using (var sw = new MemoryStream())
    {
           using (var strw = new StreamWriter(sw, System.Text.UTF8Encoding.UTF8))
           {
                  returnXML.Save(strw);
                  returnVal = System.Text.UTF8Encoding.UTF8.GetString(sw.ToArray());
           }
    }
    
    // ReturnVal has the string with XML data with XML declaration tag
