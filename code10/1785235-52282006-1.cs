    var results = (from l in MyTable
                  group l by new {l.Name, l.Service} into grp
                  where (grp.Key.Name == "dcc" && grp.Key.Service == "Main")
                      || (grp.Key.Name == "dcc" && grp.Key.Service == "DB")
                      || ....
                  select new
                  {
                      grp.Key,
                      Value = grp.OrderByDescending(x => x.Time).Select(x => x.Value).First()
                  }).ToDictionary(x => x.Key, x => x.Value);
