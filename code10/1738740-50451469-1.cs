         public string status { get; set; }
         public string message { get; set; }
         public MySubObject data { get; set; }
    }
    
    public class MySubObject 
    {
        public string trade_origin_iso3country { get; set;}
        public Dictionary<string,string> countries { get;set;}
    }
