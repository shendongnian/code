    public static class MyDbContextExtension
    {
       public static IEnumerable<Customer> GetByName(this DbSet<Customer> customers, string name)
       {
           return customers.Where(c => c.Name.Contains(name));
       }
    }
