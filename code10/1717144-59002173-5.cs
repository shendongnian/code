    static void Main(string[] args)
    {
       List<Customer> customers = new List<Customer>();
       customers.Add(new Customer { Id = 1, FirstName = "Stack" });
       customers.Add(new Customer { Id = 2, FirstName = "Overflow" });
    
       Predicate<Customer> pred = x => x.Id == 1;
       Customer customer = customers.Find(pred);
       Console.WriteLine(customer.FirstName);
       Console.Read();
    }
