     static void Main(string[] args)
            {
                var duplicateCustomers = new List<CustomerDTO>
                    {
                        new CustomerDTO { CardNumber = "123456", CustomerNumber = "1234" },
                        new CustomerDTO { CardNumber = "123456", CustomerNumber = "1234" },
                        new CustomerDTO { CardNumber = "654321", CustomerNumber = "4321" },
                        new CustomerDTO { CardNumber = "654321", CustomerNumber = "4321" }
                    };
               // var nonduplicates= duplicateCustomers.Distinct(x => x.).ToList();//duplicateCustomers.Select(x => x.CustomerNumber).Distinct().ToList();
                List<CustomerDTO> distinctCustomers = duplicateCustomers
       .GroupBy(p => p.CardNumber)
       .Select(g => g.FirstOrDefault())
       .ToList();
                foreach (var item in distinctCustomers)
                {
                    Console.WriteLine("Details  "+item.CardNumber +" "+ item.CustomerNumber + "   "+item.FetchedDate);
                    //Console.WriteLine("cust Number" + item.CustomerNumber);
                }
              
                Console.ReadLine();
            }
