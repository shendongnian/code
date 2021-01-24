    var result = new List<ExpandoObject>();
    foreach (var orders in orderList.GroupBy(obj => obj.ProductID))
    {
        var record = new ExpandoObject();
        foreach (var order in orders.AsEnumerable())
        {
            ((IDictionary<string, object>)record).Add(order.Date, order.Amount);
        }
        result.Add(record);
    }
