    class Program
    {
        static void Main(string[] args)
        {
            test t = new test();
            Console.WriteLine(t.NamedTuple.start);
            Console.WriteLine(t.NamedTuple.stop);
            Console.Read();
        }
    }
    class test
    {
        DateTime From;
        DateTime To;
       
        public (DateTime start, DateTime stop) NamedTuple
        {
            get
            {
                From = DateTime.Now.AddDays(-1).Date.AddMonths(-1);
                To = DateTime.Now.AddDays(-1).Date;
                return (From, To);
            }
        }
    }
