           var tree = invoices.GroupBy(x => x.Date).Select(x => new
                {
                    Key = x.Key,
                    Items = x.GroupBy(y => y.Customer).Select(y => new
                        {
                            Key = y.Key,
                            Items = y.Select(z => z.Id).ToList()
                        })
                }).ToList();
