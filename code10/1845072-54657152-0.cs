    var groupedData = from b in table.AsEnumerable()
                      group b by new 
                      {
                         b.Field<string>("TasksId"), 
                         b.Field<string>("Another Column")
                      } into g
                      select new
                      {
                          TaskId= g.Key,
                          Count= g.Count(),
                          Sum= g.Sum(x => x.Field<int>("Quantity"))
                      };
