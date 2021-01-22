    public static ProductsCollection GetData()
    {
        return GetDataImpl(-1, -1);
    }
    public static ProductsCollection GetData(int customerId, int supplierId)
    {
        if (customerId <= 0)
            throw new ArgumentOutOfRangeException("customerId");
        if (supplierId <= 0)
            throw new ArgumentOutOfRangeException("supplierId");
        return GetDataImpl(customerId, supplierId);
    }
    public static ProductsCollection GetCustomerData(int customerId)
    {
        if (customerId <= 0)
            throw new ArgumentOutOfRangeException("customerId");
        return GetDataImpl(customerId, -1);
    }
    public static ProductsCollection GetSupplierData(int supplierId)
    {
        if (supplierId <= 0)
            throw new ArgumentOutOfRangeException("supplierId");
        return GetDataImpl(-1, supplierId);
    }
    private static ProductsCollection GetDataImpl(int customerId, int supplierId)
    {
        if (customerId > 0)
            Filter.Add(Customers.CustomerId == customerId);
        if (supplierId > 0)
            Filter.Add(Suppliers.SupplierId == supplierId);
        ProductsCollection products = new ProductsCollection();
        products.FetchData(Filter);
        return products;
    }
