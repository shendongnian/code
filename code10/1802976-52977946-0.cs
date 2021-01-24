      List<ProductDetail> details = ResultItemsGroupBy.Select(p => new ProductDetail()
      {
        Product = p.Key, //Value you grouped by will be assigned as the Product
        Price = p.First().Price, //Assumes the price is constant for all items in the group
        Quantity = p.Sum(q => q.Quantity) //Sum will add up all the items in the group
      }).ToList();
