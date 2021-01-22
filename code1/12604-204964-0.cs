            var query = from row in table.Rows.Cast<DataRow>()
                      group row by new
                      {
                          Col1 = row.Field<int>(1),
                          Col2 = row.Field<int>(2)
                      } into grp
                      select new
                      {
                          Key = grp.Key,
                          Sum = grp.Sum(x => x.Field<int>(7))
                      };
            foreach (var item in query)
            {
                Console.WriteLine("{0},{1}: {2}",
                    item.Key.Col1, item.Key.Col2, item.Sum);
            }
