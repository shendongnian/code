    string[] dateStrings = new string[] { "2009-07-20 13:00:00",
      "2009-07-20 16:00:00", "2009-07-20 09:00:00" };
    
    var results =
    dateStrings.Select(s => 
    {
      DateTime v;
      bool parsed = DateTime.TryParse(s, out v);
      return new {Parsed = parsed, Value = v };
    })
    .Where(x => x.Parsed)
    .Select(x => x.Value)
    .OrderByDescending(d => d);
