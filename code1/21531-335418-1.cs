    using System;
    using System.Linq;
    using System.Xml.Linq;
    static void Main(string[] args)
    {
        string xml = @"<data><record id='1'/><record id='2'/><record id='3'/></data>";
        StringReader sr = new StringReader(xml);
        XDocument d = XDocument.Load(sr);
        // the verbose way, if you will be removing many elements (though in
        // this case, we're only removing one)
        var list = from XElement e in d.Descendants("record")
                   where e.Attribute("id").Value == "2" 
                   select e;
        // convert the list to an array so that we're not modifying the
        // collection that we're iterating over
        foreach (XElement e in list.ToArray())
        {
           e.Remove();
        }
        // the concise way, which only works if you're removing a single element
        // (and will blow up if the element isn't found)
        d.Descendants("record").Where(x => x.Attribute("id").Value == "3").Single().Remove();
        XmlWriter xw = XmlWriter.Create(Console.Out);
        d.WriteTo(xw);
        xw.Flush();
        Console.ReadLine();
    }
