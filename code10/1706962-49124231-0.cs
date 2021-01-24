        JavaScriptSerializer js = new JavaScriptSerializer();
        var rates = js.Deserialize<List<Item>>(jsonString);
        for (int i = 0; i < rates.Count; i++)
        {
            Item rate = new Item();
            rate = (Item)(rates[i]);
            Rates rb = (Rates)rate.rates;
        }
        public class Item
        {
            
            public string @base { get; set; }
            public string date { get; set; }
            public Rates rates { get; set; }
        }
