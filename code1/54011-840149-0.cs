    foreach(XmlElement item in doc.SelectNodes("/root/section[@name='blah']/item"))
    {
         Console.WriteLine(item.GetAttribute("name"));
         Console.WriteLine(item.InnerText);
    }
