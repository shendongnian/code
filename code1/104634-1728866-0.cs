    class foo
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    class fooEqualityComparer : IEqualityComparer<foo>
    {
        public bool Equals(foo x, foo y)
        {
            if (x == null || y == null)
                return false;
            return x.Name == y.Name;
        }
        public int GetHashCode(foo obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    var duplicates = listOfItems
    .GroupBy(x => x, new fooEqualityComparer())
    .Where(g => g.Count() > 1)
    .SelectMany(g => g);
