    //Load the document
    XDocument doc = XDocument.Load(@"PATH_TO_FILE.xml");
    
    //Extract all ID's
    var ids = new List<int>();
    foreach (var lvl in doc.Root.Elements())
    {
        if (int.TryParse(lvl.Attribute("id").Value.Replace("abc", ""), out int id))
        {
            ids.Add(id);
        }
    }
