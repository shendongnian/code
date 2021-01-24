    XmlDocument submission = new XmlDocument();
    submission.LoadXml(xml);
    
    var bookNodes = submission.SelectNodes("//*[starts-with(local-name(), 'book_')]");
    
    foreach (XmlNode book in bookNodes)
    {
        foreach(XmlNode author in book.ChildNodes)
        {
            Console.WriteLine(author.InnerXml); //Out : <name>Charlie</name><age>30</age> ...
        }
    }
