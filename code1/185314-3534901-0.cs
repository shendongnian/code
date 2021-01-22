    var query = from row in table
                group row into g
                select new
                {
                    Col1 = g.Key.Col1,
                    Col2 = g.Key.Col2,
                    Date = g.Max(b => b.Date)
                };
