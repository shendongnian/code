        return from p in ctx.Products
               select new Product
               {
                   ID = p.ID,
                   Name = p.Name,
                   Price = p.Price
                   ProductType = new Category
                   {
                       ID = p.Category.ID,
                       Name = p.Category.Name // etc.
                   }
               };
