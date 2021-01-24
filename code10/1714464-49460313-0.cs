    using (WebClient client = new WebClient())
    {
      var url = "http://es.fifa.com/worldcup/archive/brazil2014/statistics/players/goal-scored.html";
      var web = new HtmlWeb();
      var doc = web.Load(url);
    
      var table = doc.DocumentNode.Descendants().Where(dn => dn.HasClass("tbl-statistics")).FirstOrDefault();
    
      var cells = table.SelectNodes("//tbody/tr/td");
    
      var cellsGroupedByTr = cells.GroupBy(c => c.ParentNode);
    
      foreach (var group in cellsGroupedByTr)
      {
        var tr = group.Key;
        var trCells = group.ToArray();
    
        var cellStrings = trCells.Select(c => c.InnerText).ToArray();
        Console.WriteLine(string.Join(", ", cellStrings));
    
      }
    }
