        var Results_Exchange_Kraken = JsonConvert.DeserializeObject<DataRoot_Kraken>(Content_Exchange_Kraken);
                       
                        
        var price_data_kraken = Results_Exchange_Kraken.result.XETHZUSD;
        public class Kraken_Result
        {
            public List<List<object>> XETHZUSD { get; set; }
            public int last { get; set; }
        }
        public class DataRoot_Kraken
        {
            public List<object> error { get; set; }
            public Kraken_Result result { get; set; }
        }
