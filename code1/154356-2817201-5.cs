    using (var reader = SqlHelper.ExecuteReader(...))
    {
        while (reader.Read())
        {
            yield return new Order()
            {
                OrderId = reader.GetInt32("orderId"),
                ItemId = reader.GetInt32("itemId")
            };
        }
    }
