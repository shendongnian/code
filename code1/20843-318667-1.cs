            // the data
            var outer = new[] {
                new[] {
                    new {ID=1,Amount=4}, // [0] [Child_0] [ID: 1, Amount: 4]
                    new {ID=2,Amount=7}  // [0] [Child_1] [ID: 2, Amount: 7]
                },
                new[] {
                    new {ID=1, Amount=2}, // [1] [Child_0] [ID: 1, Amount: 2]
                    new {ID=2, Amount=4}  // [1] [Child_1] [ID: 2, Amount: 4]
                },
                new[] {
                    new {ID=1, Amount=5}, // [2] [Child_0] [ID: 1, Amount: 5]
                    new {ID=2, Amount=3}  // [2] [Child_1] [ID: 2, Amount: 3]
                }
            };
            var qry = from x in outer
                      from y in x
                      group y by y.ID into grp
                      select new { Id = grp.Key, Avg = grp.Average(z => z.Amount) };
            foreach (var item in qry)
            {
                Console.WriteLine("{0}: {1}", item.Id, item.Avg);
            }
