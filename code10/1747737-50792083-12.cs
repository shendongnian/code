    var brands = _context.Brands
                .Select(b => new
                {
                    b,
                    FoodCategories = b.FoodCategories
                        .Where(x => x.BrandId == b.BrandId)
                        .Select(c => new
                        {
                            c,
                            Products = c.Products
                                .Where(y => y.FoodCategoryId == c.FoodCategoryId 
                                            && y.Sugar)                           //HERE!
                                .Select(p => new
                                {
                                    p,
                                    File = p.FileDetail
                                })
                        })
                })
                .AsEnumerable()
                .Select(z => z.b)
                .ToList();
