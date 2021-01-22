    var query = foos
                .GroupBy(x => new { x.Category, x.Code })
                .Select(g => new Foo
                    {
                        Category = g.Key.Category,
                        Code = g.Key.Code,
                        Quantity = g.Sum(x => x.Quantity)
                    });
