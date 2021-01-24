    public class Data
    {
      public int Number { get; set; }
      public string Area { get; set; }
    }
    
    var objects = JsonConvert.DeserializeObject<List<Data>>(File.ReadAllText(path, Encoding.UTF8))
      .Select(d => new object { Number = d.Number })
      .ToList();
    
    EFBatchOperation.For(db, db.Entity).InsertAll(objects);
