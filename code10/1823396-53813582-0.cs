        class Program
        {
            
            
            static void Main(string[] args)
            {
                Context _context = new Context();
                var ids = (from c in _context.customers
                           join t in _context.transactions on c.Id equals t.CustomerId
                           select new { c = c, t = t})
                           .OrderByDescending(x => x.c.Created)
                           .Take(10)
                           .ToList();
      
            }
        }
        public class Context
        {
            public List<Customer> customers { get; set; }
            public List<Transaction> transactions { get; set; }
        }
        public class Customer
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime Created { get; set; }
            public HashSet<Transaction> Transactions { get; set; }
        }
        public class Transaction
        {
            public Guid Id { get; set; }
            public decimal Amount { get; set; }
            public DateTime Created { get; set; }
            public Guid CustomerId { get; set; }
            public Customer Customer { get; set; }
        }
     
