    string s = "<?xml version=\"1.0\"?><tag1><tag2>Some text.</taagg2></tag1>";
    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    
    try
    {
        doc.LoadXml(s);
    }
    catch(System.Xml.XmlException ex)
    {
        MessageBox.Show(ex.LineNumber.ToString());
        MessageBox.Show(ex.LinePosition.ToString());
    }
