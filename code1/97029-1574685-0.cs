    public static IEnumerable<Order> GetOrdersWithProducts(params int[] ids)
    {
        return GetOrdersWithProducts((IEnumerable<int>) ids);
    }
    public static IEnumerable<Order> GetOrdersWithProducts(IEnumerable<int> ids)
    {
        return orders.Where(o => !ids.Except(o.Items.Select(p => p.ProductId))
                                     .Any());
    }
    var result1 = GetOrdersWithProducts(3);
    var result2 = GetOrdersWithProduct(4, 5);
