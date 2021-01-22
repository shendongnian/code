            var query = from row in table.Rows.Cast<DataRow>()
                      group row by new
                      {
                          Col1 = row.Field<int>(1),
                          Col2 = row.Field<int>(2)
                      } into grp
                      select new
                      {
                          Col1 = grp.Key.Col1,
                          Col2 = grp.Key.Col2,
                          SumCol7 = grp.Sum(x => x.Field<int>(7))
                      };
            foreach (var item in query)
            {
                Console.WriteLine("{0},{1}: {2}",
                    item.Col1, item.Col2, item.SumCol7);
            }
