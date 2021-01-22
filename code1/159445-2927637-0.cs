    var colorDistributionSql = 
        from product in ctx.Products
        group product by product.Color
        into productColors
    
        select
           new 
        {
           Color = productColors.Key,
           Count = productColors.Count()
        };
    var colorDistributionList = colorDistributionSql
          .AsEnumerable()
          .ToList(x => new ProductColour(x.Color, x.Count));
