    class Program
    {
        public class Transaction { public DateTime date { get; set; } }
        public class Parameter { public string Constraint { get; set; } }
        public static void Main()
        {
            IEnumerable<Transaction> transactions = new List<Transaction> {
                new Transaction { date = new DateTime(2009, 10, 5) },
                new Transaction { date = new DateTime(2009, 11, 3) }
            };
            Parameter parameter = new Parameter { Constraint = "2009-11-01" };
            DateTime startDate = DateTime.Parse(parameter.Constraint);
            // Version 1.
            transactions = transactions.Where(T => T.date >= startDate);
            // Version 2.
            transactions = transactions.Where(T => T.date >= DateTime.Parse(parameter.Constraint));
    
        }
    }
