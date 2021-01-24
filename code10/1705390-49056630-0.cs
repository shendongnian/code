     public class Value
        {
            public IList<string> ColumnNames { get; set; }
            public IList<string> ColumnTypes { get; set; }
            public IList<IList<string>> Values { get; set; }
        }
    
        public class WSOutput
        {
            public string type { get; set; }
            public Value value { get; set; }
        }
    
        public class Results
        {
            public WSOutput WSOutput { get; set; }
        }
    
        public class Example
        {
            public Results Results { get; set; }
        }
