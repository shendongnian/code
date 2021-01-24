    public class OrderFund 
    {
        public int OrderID { get; set; }
        public int BrokerID { get; set; }
        public string SettlementMethod { get; set; }
        [JsonProperty("Settlements")] 
        public List<SettlementSap> SettlementsSap { get; set; }
    }
