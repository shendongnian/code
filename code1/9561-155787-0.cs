    public static void ReplaceOrAdd(this XElement source, XElement node)
     { var q = from x in source.Elements()
               where    x.Name == node.Name
                     && x.Attributes().All
                                       (a =>node.Attributes().Any
                                       (b =>a.Name==b.Name && a.Value==b.Value))
               select x;
                     
       var n = q.LastOrDefault();
                                   
       if (n == null) source.Add(node);
       else n.ReplaceWith(node);                                                  
     }
    var root   =XElement.Parse(data);
    var newElem=XElement.Parse(@"<thing2 a1=""a"" a2=""b"">new value</thing2>");
    root.ReplaceOrAdd(newElem);
