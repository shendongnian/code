    public virtual ReadOnlyCollection<Product> Products
    {
        get
        {
            return new List<Product>(_products).AsReadOnly();
        }
    }
