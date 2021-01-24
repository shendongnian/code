    List<EmployeesDto> Employees = new List<EmployeesDto>();
    List<AccountsDto> Accounts = new List<AccountsDto>();
    var linkedEmployees = Employees
                             .Select(e => 
                                 new LinkedEmployeesDto
                                      { EmpId = e.EmpId, 
                                        EmpName = e.EmpName,
                                        IsManager = Accounts
                                                   .Single(a => a.EmpId == e.EmpId)
                                                   .IsManager
                                      })
                             .ToList();
