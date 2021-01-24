    foreach (var e in x.Descendants("chkr"))
    {
        foreach (var v in e.Descendants()
                           .Where(ee => ee.Name != "ab" && ee.Name != "tt")
                           .GroupBy(ee => ee.Name)
                           .Select(ee => new { Name = ee.Key, Count = ee.Count() }))
        {
            if (v.Count > 1)
                Console.WriteLine($"<chkr id={e.Attribute("id").Value}> contains the the tag <{v.Name}> {v.Count} times.");
        }
    }
