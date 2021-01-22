    using System;
    using System.Xml.Serialization;
    
    public class Data {
        public decimal? Amount { get; set; }
        public bool ShouldSerializeAmount() {
            return Amount != null;
        }
        static void Main() {
            Data d = new Data();
            XmlSerializer ser = new XmlSerializer(d.GetType());
            ser.Serialize(Console.Out, d);
            Console.WriteLine();
            Console.WriteLine();
            d.Amount = 123.45M;
            ser.Serialize(Console.Out, d);
        }
    }
