    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var customers = doc.Descendants("customer").GroupBy(x => (string)x.Attribute("ID")).ToList();
                foreach (var customer in customers)
                {
                    XElement firstAccount = customer.FirstOrDefault();
                    XElement firstServices = firstAccount.Element("services");
                    XElement firstCustomerField = firstAccount.Element("customFields");
                    for (int i = customer.Count() - 1; i >= 1; i--)
                    {
                        XElement account = customer.Skip(i).FirstOrDefault();
                        List<XElement> services = account.Descendants("service").ToList();
                        firstServices.Add(services);
                        List<XElement> customFields = account.Descendants("customField").ToList();
                        firstCustomerField.Add(customFields);
                        account.Remove();
                    }
                }
     
            }
     
        }
     
    }
