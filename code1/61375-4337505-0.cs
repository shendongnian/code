    var xdoc = new XDocument(new XElement("Root", new XElement("Child", "台北 Táiběi.")));
        
    string mystring;
        
    using(var sw = new MemoryStream())
    {
        using(var strw = new StreamWriter(sw, System.Text.UTF8Encoding.UTF8))
        {
             xdoc.Save(strw);
             mystring = System.Text.UTF8Encoding.UTF8.GetString(sw.ToArray());
        }
    }
