        var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
        var result = Collection.Aggregate<Order>()
            .Match(filter)
            .Unwind(a => a.OrderProducts)
            .Lookup(nameof(Product), $"{nameof(Order.OrderProducts)}.{nameof(OrderProduct.ProductId)}", "_id", nameof(Product))
            .Unwind(nameof(Product))
            .Group(new BsonDocument
              {
                   { "_id", "_id" },
                   { nameof(Order.Total) , new BsonDocument("$first", $"${nameof(Order.Total)}")},
                   { nameof(Order.OrderProducts),
                        new BsonDocument("$push",
                            new BsonDocument() {
                                { "_id", $"${nameof(Product)}._id" },
                                { nameof(Product.Name), $"${nameof(Product)}.{nameof(Product.Name)}" },
                                { nameof(Product.Price), $"${nameof(Product)}.{nameof(Product.Price)}" },
                                { nameof(OrderProduct.Quantity), $"${nameof(OrderProduct)}s.{nameof(OrderProduct.Quantity)}" }
                            }
                   )},
              })
            .FirstOrDefault();
