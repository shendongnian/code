            using(var ctx = new DataClasses1DataContext())
            {
                ctx.Log = Console.Out;
                var qry = from boss in ctx.Employees
                          join grunt in ctx.Employees
                              on boss.EmployeeID equals grunt.ReportsTo into tree
                          from tmp in tree.DefaultIfEmpty()
                          select new
                                 {
                                     ID = boss.EmployeeID,
                                     Name = tmp == null ? "" : tmp.FirstName
                            };
                foreach(var row in qry)
                {
                    Console.WriteLine("{0}: {1}", row.ID, row.Name);
                }
            }
