      var result = data.GroupBy(x => new { x.String1, x.Int1, x.Int2 })
                            .Select(g => new
                            {
                                String1 = g.Key.String1,
                                Int1 = g.Key.Int1,
                                Int2 = g.Key.Int2,
                                AvgDecimal1 = g.Select(x => x.Decimal1).Average(),
                                AvgDecimal2 = g.Select(x => x.Decimal1).Average(),
                                AvgDecimalN = g.Select(x => x.Decimal1).Average()
                            }).ToList();
