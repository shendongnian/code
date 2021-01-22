    XDocument xdoc = XDocument.Load("data.xml");
    var lv1s = xdoc.Root.Descendants("level1"); 
    var lvs = lv1s.SelectMany(l=>
         new string[]{ l.Attribute("name").Value }
         .Union(
             l.Descendants("level2")
             .Select(l2=>"   " + l2.Attribute("name").Value)
          )
        );
    foreach (var lv in lvs)
    {
       result.AppendLine(lv);
    }
