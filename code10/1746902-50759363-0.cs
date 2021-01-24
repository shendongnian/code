    var grouped = nonGrouped.GroupBy(x => new
                {
                    x.Id,
                    x.Col1,
                    x.Col2
                }).Select(x => new MyDbTable
                {
                    Id = x.Key.Id,
                    VALUE = x.Sum(y => y.Value),
                    Col1 = x.Key.Col1,
                    Col2 = x.Key.Col2
                }).Where(z => z.Col1 != z.Col2).ToList();
