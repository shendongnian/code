     public class OrderFund 
        {
            public int OrderID { get; set; }
            public int BrokerID { get; set; }
            public string SettlementMethod { get; set; }
            public List<SettlementSap> Settlements { get; set; }
        }
