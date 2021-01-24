            public class OrderFund
            {
                public string settlementMethod { get; set; }
                public int BrokerID { get; set; }
                public int OrderID { get; set; }
                public Settlement[] Settlements { get; set; }
            }
    
            public class Settlement
            {
                public string SapMonetaryAccountNo { get; set; }
                public string SapMonetaryAccountType { get; set; }
                public string SapMonetaryAccountOffice { get; set; }
            }
