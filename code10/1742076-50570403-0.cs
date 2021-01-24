    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    public class tranx
    {
        public Transaction transaction { get; set; }
        public List<LineItem> lineItems { get; set; }
    }
    
    public class LineItem { }
    public class Transaction { }
    
    class Program
    {
        static void Main()
        {
            string json = File.ReadAllText("test.json");
            tranx t = JsonConvert.DeserializeObject<tranx>(json);
        }
    }
