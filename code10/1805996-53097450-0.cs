       public class Rates
        {
            public double AUD { get; set; }
        }
    
        public class ObjectCurrency
        {
            public string date { get; set; }
            public Rates rates { get; set; }
            public string @base { get; set; }
        }
      var data= JsonConvert.DeserializeObject<ObjectCurrency>(exchRateData);
