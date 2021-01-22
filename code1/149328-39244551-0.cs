  For type 
  public class KeyValue
    {
        public string KeyCol { get; set; }
        public string ValueCol { get; set; }
    }
     & collection below
    var wordList = new Model.DTO.KeyValue[] {
     new Model.DTO.KeyValue {KeyCol="key1", ValueCol="value1" },
     new Model.DTO.KeyValue {KeyCol="key2", ValueCol="value1" },
     new Model.DTO.KeyValue {KeyCol="key3", ValueCol="value2" },
     new Model.DTO.KeyValue {KeyCol="key4", ValueCol="value2" },
     new Model.DTO.KeyValue {KeyCol="key5", ValueCol="value3" },
     new Model.DTO.KeyValue {KeyCol="key6", ValueCol="value4" }
    };
    
    our linq query look like below
    var query =from m in wordList group m.KeyCol by m.ValueCol into g
    select new { Name = g.Key, KeyCols = g.ToList() };
      or for array instead of list like below
    var query =from m in wordList group m.KeyCol by m.ValueCol into g
    select new { Name = g.Key, KeyCols = g.ToList().ToArray<string>() };
