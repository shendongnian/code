        public T Value { get; set; }
    }
    
    class MyContext : DbContext
    {
        public DbSet<Benchmark> Benchmarks { get; set; }
        public DbQuery<ScalarResult<double>> Doubles { get; set; }
    }
    var db = new MyContext();
    var stdev = Enumerable.Single(
        from r in db.Doubles.FromSql("SELECT STDEV(Result) AS Value FROM Benchmarks") select r.Value);
