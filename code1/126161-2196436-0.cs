    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class MezeoAccount
    {
        public string PsoId { get; set; }
        public string Email { get; set; }
        public int QuotaMeg { get; set; }
        // Other properties...
    }
    
    public class Program
    {
        public static void Main()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><searchResponse requestID=\"500\" status=\"success\"><pso><psoID ID=\"61F2C644-F93A-11DE-8015-73A11AB14291\" targetID=\"mezeoAccount\"><data><email>sholobfc@bluefire.com.au</email><quotaMeg>2048</quotaMeg><quotaUsed>1879736</quotaUsed><active>true</active><unlocked>true</unlocked><allowPublic>true</allowPublic><realm>mezeo</realm><bandwidthQuota>1000000000</bandwidthQuota><billingDay>1</billingDay></data></psoID></pso></searchResponse>";
            XDocument doc = XDocument.Parse(xml);
            XElement psoId = doc.Element("searchResponse")
                                .Element("pso")
                                .Element("psoID");
            XElement data = psoId.Element("data");
            MezeoAccount x = new MezeoAccount
            {
                PsoId = psoId.Attribute("ID").Value,
                Email = data.Element("email").Value,
                QuotaMeg = int.Parse(data.Element("quotaMeg").Value),
                // Other properties...
            };
        }
    }
