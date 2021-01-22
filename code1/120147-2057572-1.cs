    public virtual ReadOnlyCollection<Product> Products
    {
        get
        {
            return _products.AsReadOnly();
        }
    }
