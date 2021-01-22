    XElement e = XElement.Parse(testStr);
    string groupName = "GroupB";
    var items = from g in e.Elements(groupName)
                from i in g.Elements("Item")
                select new {
                               attr1 = i.Attribute("attrib1"),
                               attr2 = i.Attribute("attrib2")
                           };
    foreach (var item in items)
    {
        Console.WriteLine(item.attr1 + ":" + item.attr2);
    }
