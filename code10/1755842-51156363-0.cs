    class Supplier
    {
        public string Ref { get; set; }
        public string Name { get; set; }
    }
    class SupplierComparer : Comparer<Supplier>
    {
        public override int Compare(Supplier x, Supplier y)
        {
            var compareRef = x.Ref.CompareTo(y.Ref);
            if (compareRef != 0)
            {
                return compareRef;
            }
            var compareName = x.Name.CompareTo(y.Name);
            if (compareName != 0)
            {
                return compareName;
            }
            return 0;
        }
    }
    
    public void MyTestMethod()
    {
        var suppliers = new[]
        {
            new Supplier { Ref = "abc", Name = "steve" },
            new Supplier { Ref = "abc", Name = "bob" },
            new Supplier { Ref = "cde", Name = "ian" },
            new Supplier { Ref = "fgh", Name = "dan" }
        };
        var comparer = new SupplierComparer();
        suppliers.Should().BeInAscendingOrder(comparer);
    }
