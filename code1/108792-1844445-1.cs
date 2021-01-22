    using Microsoft.Office.Interop.Outlook;
            static void Main(string[] args)
            {
                Application app = new Microsoft.Office.Interop.Outlook.Application();
                foreach (AddressList addressList in app.Session.AddressLists)
                {
                    foreach (AddressEntry item in addressList.AddressEntries)
                    {
                        Console.WriteLine(item.Address);
                        ContactItem contact = item.GetContact();
                        if (contact != null)
                        {
                            Console.WriteLine(contact.Title);
                            Console.WriteLine(contact.BusinessAddress);
                            Console.WriteLine(contact.BusinessAddressCity);
                            Console.WriteLine(contact.BusinessAddressState);
                            Console.WriteLine(contact.BusinessTelephoneNumber);
                        }
                        Console.WriteLine();
                    }
                    
                }
                Console.Read();
            }
