    XPathDocument myXPathDocument = new XPathDocument ("books.xml");
    XslTransform myXslTransform = new XslTransform();
    myXslTransform.Load("books.xsl");
    
    XmlTextWriter writer = new XmlTextWriter("ISBNBooks.xml",System.Text.Encoding.UTF8);
    myXslTransform.Transform(myXPathDocument,null, writer);
    writer.Close();
    
    System.IO.StringWriter stWrite = new System.IO.StringWriter();
    myXslTransform.Transform(myXPathDocument, null, stWrite);
