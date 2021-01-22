    static void Main(string[] args)   
    {   
        using(var db = new DataContext())   
        {   
            db.Customers.Where(c => c.Country == "USA").Update(c => new Customer()   
            {   
                Country = "IN"   
            });   
       
            foreach(var customer in db.Customers.ToList())    
            {   
                Console.WriteLine("CustomerInfo - {0}-{1}-{2}", customer.Name, customer.Country, customer.Status);   
            }   
        }   
       
        Console.ReadLine();   
    }
   
