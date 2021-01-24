    var departments = new List<Dept>(); // ? fill
    var result = 
                  departments.GroupBy(d => d.Category)
                             .Select(g => new NewModel
                                          {
                                              Category = g.Key,
                                              EmpNames = g.SelectMany(d => d.Employees)
                                                          .Where(e => e.Type == "A")   
                                                          .Select(e => e.Name) 
                                          });  
