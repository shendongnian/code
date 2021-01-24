    Regex r = new Regex(@"^(?<fieldName>(\d\.)+(?<index>\d*)), *Type: *(?<dataType>.*), *Value: (?<dataValue>.*)$");
        
    public class MyData
    {
        public DateTime DateTime { get; set; }
        public int Index { get; set; }
        public string Value { get; set; }
    }
    class LogRow
    {
        public int Index { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
    //In a parser I would rather not be too defensive, I let exceptions bubble up
    IEnumerable<LogRow> ParseRows(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
           var match = r.Matches(line).AsQueryable().Cast<Match>().Single();
           if (match != null)
           {
              yield return new LogRow()
              {
                  Index = int.Parse(match.Groups["index"].Value),
                  Type = match.Groups["dataType"].Value,
                  Value = match.Groups["dataValue"].Value
              };
           }
           //probably add else with logging/exception
       }
    }
    IEnumerable<MyData> RowsToData(IEnumerable<LogRow> rows)
    {
       var byIndex = rows.GroupBy(b => b.Index).OrderBy(b=> b.Key);
       foreach (var group in byIndex)
       {
           string rawDate = group.SingleOrDefault(g => g.Type == "DateTime").Value;
           string value = group.SingleOrDefault(g => g.Type == "String").Value;
           var date = DateTime.ParseExact(rawDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
           yield return new MyData() { Index = group.Key, DateTime = date, Value = value };
           //you can also do this instead of what is written above
           //var rawRow = group.ToDictionary(g => g.Type, g => g);
           //var date = DateTime.ParseExact(rawRow["DateTime"].Value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
          //yield return new MyData() { Index = group.Key, DateTime = date, Value = rawRow["String"].Value };
      }
    }
