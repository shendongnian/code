    var result = depts.SelectMany(x => x.Employees.Where(z => z.Type == "A")
                               , (DeptObj, empObj) =>
                                                    new
                                                    {
                                                        DeptObj.Category,
                                                        empObj
                                                    }
                                                  ).GroupBy(x => x.Category)
                                                  .Select(x => 
                            new NewModel 
                             { 
                                 Category = x.Key, 
                                 EmpNames = x.Select(z => z.empObj.Name).ToList() 
                             });
