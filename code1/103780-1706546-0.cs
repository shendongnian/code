    var products = from product in Products
                   group product by product.Supplier into groupedProducts
                   let totalPrice = groupedProducts.Sum(p => p.UnitPrice)
                   orderby totalPrice
                   select new
                   {
                       groupedProducts.Key.CompanyName,
                       LowestPrice = groupedProducts.Min(p => p.UnitPrice),
                       HighestPrice = groupedProducts.Max(p => p.UnitPrice),
                       AveragePrice = groupedProducts.Average(p => p.UnitPrice),
                       TotalPrice = totalPrice
                   };
