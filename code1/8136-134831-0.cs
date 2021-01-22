    CSVReader csvReader = new CSVReader();
    List<string> source = new List<string>();
    using(StreamReader sr = new StreamReader(myFileName))
    {
      while (!sr.EndOfStream)
      {
        source.Add(sr.ReadLine());
      }
    }
    List<string> ServMissing =
      source
      .Where(s => s.StartsWith(" ")
      .ToList();
    //--------------------------------------------------
    List<IGrouping<string, string>> groupedSource = 
    (
      from s in source
      where !s.StartsWith(" ")
      let parsed = csvReader.CSVParser(s)
      where parsed.Any()
      let first = parsed.First()
      let rest = String.Join( "," , parsed.Skip(1).ToArray())
      select new {first, rest}
    )
    .GroupBy(x => x.first, x => x.rest)   //GroupBy(keySelector, elementSelector)
    .ToList()
    //--------------------------------------------------
    List<string> myExtras = new List<string>();
    foreach(IGrouping<string, string> g in groupedSource)
    {
      myHashTable.Add(g.Key, g.First());
      if (g.Skip(1).Any())
      {
        myExtras.Add(g.Key);
      } 
    }
