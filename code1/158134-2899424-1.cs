    var key = Console.ReadKey();
    
    XmlSerializer s = new XmlSerializer(typeof(string));
    
    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
    {
        s.Serialize(ms, key.KeyChar.ToString());
    
        ms.Position = 0;
    
        var foo = (string)s.Deserialize(ms);
    }
