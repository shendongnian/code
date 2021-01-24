    List<string> names = new List<string>();
    List<int> counts = new List<int>();
    
    foreach (var e in x.Descendants("chkr"))
    {
        names = new List<string>();
        counts = new List<int>();
    
        foreach (var v in e.Descendants().Where(ee => ee.Name != "ab" && ee.Name != "tt").GroupBy(ee => ee.Name).Select(ee => new { Name = ee.Key, Count = ee.Count() }))
        {
            if (v.Count > 1)
            {
                names.Add(v.Name.ToString());
                counts.Add(v.Count);
            }
        }
    
        if (names.Any())
            Console.WriteLine($"<chkr id={e.Attribute("id").Value}> contains the tag/tags {String.Join(",", names)} {String.Join(",", counts)} times.");
    }
