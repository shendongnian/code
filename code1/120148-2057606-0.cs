    private List<Product> _products = new List<Product>();
    private ReadOnlyCollection<Product> _readonlyProducts =
        new ReadOnlyCollection(_products);
    public ReadOnlyCollection<Product> Products
    {
        get
        {
            return _readonlyProducts;
        }
    }
