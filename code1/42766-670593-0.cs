    //Another option:
    XDocument xdoc = XDocument.Load("data.xml"));
    var lv1s = from lv1 in xdoc.Root.Descendants("level1"); 
    var lvs = lv1s.Select(l=>l.Attribute("name").Value)
          .Union(
              lv1s.SelectMany(l=> 
                  l.Descendants("level2")
                  .Select(l2=>"   " + l2.Attribute("name").Value)
          );
    foreach (var lv in lvs)
    {
       result.AppendLine(lv);
    }
