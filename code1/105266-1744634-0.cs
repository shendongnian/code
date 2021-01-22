    using System;
    using System.Xml.Serialization;
    public class Amount
    {
        public const string CoreNamespace = "http://core.test.com/";
        [XmlElement("Amount", Namespace=CoreNamespace)]
        public decimal Value { get; set; }
        [XmlElement("CurrencyCode", Namespace = CoreNamespace)]
        public string Currency { get; set; }
    }
    [XmlType("SecurityHolding", Namespace = SecurityHolding.TradingNamespace)]
    public class SecurityHolding
    {
        public const string TradingNamespace = "http://personaltrading.test.com/";
    
        [XmlElement("Amount", Namespace = Amount.CoreNamespace)]
        public Amount Amount { get; set; }
    
        public int BrokerageId { get; set; }
        public string BrokerageName { get; set; }
        public int RecordId { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            var data = new[] {
                new SecurityHolding {
                    Amount = new Amount {
                        Value = 1.05M,
                        Currency = "USD"
                    },
                    BrokerageId = 0,
                    BrokerageName = null,
                    RecordId = 3681
                }
            };
            var ser = new XmlSerializer(data.GetType(),
                new XmlRootAttribute("ArrayOfSecurityHolding") { Namespace = SecurityHolding.TradingNamespace});
            var ns = new XmlSerializerNamespaces();
            ns.Add("foo", Amount.CoreNamespace);
            ser.Serialize(Console.Out, data, ns);
        }
    }
