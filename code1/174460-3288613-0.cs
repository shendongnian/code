using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
namespace test_xml3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer> {
                new Customer {FirstName="Jim", LastName="Smith", Age=27},
                new Customer {FirstName="Hank", LastName="Moore", Age=28},
                new Customer {FirstName="Jay", LastName="Smythe", Age=44}
            };
            Console.WriteLine(BuildXmlWithLINQ(customers));
            Console.ReadLine();
        }
        private static string BuildXmlWithLINQ(List<Customer> customers)
        {
            XDocument xdoc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("customers",
                    from c in customers select
                        new XElement("customer", 
                            new XElement("firstName", c.FirstName),
                            new XElement("lastName", c.LastName)
                        )
                )
                
            );
            return xdoc.Declaration.ToString() + Environment.NewLine + xdoc.ToString();
        }
    }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
