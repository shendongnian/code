        return from c in ctx.Categories
                where c.ID == id
                select new Category
                {
                    ID = c.ID,
                    Name = c.Name,
                    ProductList = from p in c.Products
                                  select new Product
                                  {
                                      ID = p.ID,
                                      Name = p.Name,
                                      Price = p.Price
                                  }
                };
