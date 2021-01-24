    var rawComplexData = db.Database.SqlQuery<ComplexProductDto>(dynamicSearchQuery).ToList(); 
    var prodResult = rawComplexData
      .GroupBy(x => new { x.Id, x.ProductDesc, ... })
      .Select(x => new ComplexProductModel {
          id = x.Key.Id,
          desc = x,Key.ProductDesc,
          .... // etc.
          images = x.Select(i => i.ProdImgThumb).ToList()
      });
