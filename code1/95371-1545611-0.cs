    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ReadXmlSpike
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Reading file...");
                XDocument doc = XDocument.Load("Customers.xml");
                var customers =
                    new
                        {
                            DID = (string) doc.Element("Customers").Attribute("did"),
                            DTime = (DateTime) doc.Element("Customers").Attribute("dTime"),
                            Customers = from customerxml in doc.Descendants("Customer")
                                        select
                                            new
                                                {
                                                    ID = (string)customerxml.Attribute("id"),
                                                    Orders = from orderxml in customerxml.Descendants("Order")
                                                             select
                                                                 new
                                                                     {
                                                                         Number =(string) orderxml.Attribute("number")
                                                                     }
                                                }
                        };
                Console.WriteLine("Customersfile with id: {0} and time {1}",customers.DID,customers.DTime);
                foreach (var customer in customers.Customers)
                {
                    Console.WriteLine("Customer with id {0} has the following orders:",customer.ID);
                    foreach (var order in customer.Orders)
                    {
                        Console.WriteLine("Order with number {0}",order.Number);
                    }
                }
                Console.ReadLine();
            }
        }
    }
