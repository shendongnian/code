    class MyClass
    {
        public IQueryable<int> Where(Func<int, bool> predicate)
        {
            return Enumerable.Range(1, 100).AsQueryable();
        }
    }
    static void Main(string[] args)
    {
        var q = from p in new MyClass()
                where p == 10
                select p;      
    }
