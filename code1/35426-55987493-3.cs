        class EnumeratorExample
        {
            static void Main(String[] args)
            {
        
                CustomerList custList = new CustomerList();
                foreach (Customer cust in custList)
                {
                    Console.WriteLine("Customer Name:"+cust.Name + " City Name:" + cust.City + " Mobile Number:" + cust.Amount);
                }
                Console.Read();
        
            }
        }
