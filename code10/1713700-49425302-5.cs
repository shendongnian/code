        static void Main(string[] args)
        {
            tests.Add(new testtable() { Price = 10, TransactionDate =new DateTime(2018,1,1,0,0,0) });
            tests.Add(new testtable() { Price = 20, TransactionDate = new DateTime(2018, 1, 2, 0, 0, 0) });
            tests.Add(new testtable() { Price = 30, TransactionDate = new DateTime(2018, 3, 1, 0, 0, 0) });
            tests.Add(new testtable() { Price = 40, TransactionDate = new DateTime(2018, 3, 2, 0, 0, 0) });
            ExecQuery(c => c.Sum(a => a.Price));
            ExecQuery(c => c.Count());
        }
