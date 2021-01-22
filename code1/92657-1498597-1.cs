    var companies = dataContext.Companies.Where(cp.Compile())
                    .Select(x => new
                                     {
                                         x.Name,
                                         SumOfSalaries = x.Employees
                                            .Where( ep.Compile() )
                                            .Sum(y => y.Salary),
                                     }
                       
                     ).ToList();
