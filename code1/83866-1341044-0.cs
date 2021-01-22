    var q = from e in Context.Employees
            where e.Division.Id = divisionId
            select new
            {
                Name = e.Name,
                EmployeeType = e.EmployeeType.Description,
                ComputerIds = from c in e.Computers
                              select new 
                              {
                                  Id = c.Id
                              }
            };
