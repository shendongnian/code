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
            XDocument doc = XDocument.Load("input.xml");
            XElement pso = doc.Element("searchResponse").Element("pso");
            XElement data = pso.Element("data");
            MezeoAccount x = new MezeoAccount
            {
                PsoId = pso.Element("psoID").Attribute("ID").Value,
                Email = data.Element("email").Value,
                QuotaMeg = int.Parse(data.Element("quotaMeg").Value),
                // Other properties...
            };
        }
    }
