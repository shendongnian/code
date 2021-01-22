    using System;
    using Microsoft.Office.Interop.Outlook;
    static class Program
    {
        static void Main(string[] args)
        {
            ExchangeUser oExUser;
            Application app = new Microsoft.Office.Interop.Outlook.Application();
            foreach (AddressList addressList in app.Session.AddressLists)
            {
                if (addressList.Name == "Global Address List")
                {
                    foreach (AddressEntry item in addressList.AddressEntries)
                    {
                        Console.WriteLine(item.Address);
                        oExUser = item.GetExchangeUser();
                        if (oExUser != null) 
                        {
                            Console.WriteLine(oExUser.FirstName);
                            Console.WriteLine(oExUser.LastName);
                            Console.WriteLine(oExUser.StreetAddress);
                            Console.WriteLine(oExUser.CompanyName);
                            Console.WriteLine(oExUser.Department);
                            Console.WriteLine(oExUser.OfficeLocation);
                            Console.WriteLine(oExUser.JobTitle);
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.Read();
        }
    }
