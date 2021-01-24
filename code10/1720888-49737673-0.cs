    Persons.Select(p=>new EmployeeDemographic {
                          EmployeeName = p.Name,
                          EmployeeName = p.Company.Name,
                          Contacts = p.Contacts.ToList()
                   }).ToList();
