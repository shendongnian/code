    Persons.Select(p=>new EmployeeDemographic {
                          EmployeeName = p.Name,
                          EmployeeName = p.Company.Name,
                          Contacts = p.Contacts.ToList()
                   }).ToList();
    from p in Persons
    from c in Companies where p.CompanyId == c.Id
    ...
