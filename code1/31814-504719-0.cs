    XDocument doc1 = XDocument.Parse(@"<XML><A/><C/></XML>");
    XDocument doc2 = XDocument.Parse(@"<XML><B/><C/></XML>");
    //
    var query1 = doc1.Descendants().Union(doc2.Descendants());
    Console.WriteLine(query1.Count());
    foreach (XElement e in query1) Console.WriteLine("--{0}",e.Name);
    6
    --XML
    --A
    --C
    --XML
    --B
    --C
    //
    var query2 = doc1.Descendants().Concat(doc2.Descendants())
      .GroupBy(x => x.Name)
      .Select(g => g.First());
    Console.WriteLine(query2.Count());
    foreach (XElement e in query2) Console.WriteLine("--{0}", e.Name);
    4
    --XML
    --A
    --C
    --B
