    var brands = _context.Brands
                .Select(b => new
                {
                    b,
                    FoodCategories = b.FoodCategories
                        .Select(c => new
                        {
                            c,
                            Products = c.Products
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
