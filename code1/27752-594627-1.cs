    public BuilderInclusionsForm(Product p) : this()
    {
        IEnumerable<Product> ps = db2.GetTable(p.GetType()).Cast<Product>();
        product = ps.SingleOrDefault(a => a.ProductID == p.ProductID);
    }
