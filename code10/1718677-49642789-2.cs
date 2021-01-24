    List<EmployeesDto> Employees = new List<EmployeesDto>();
    List<AccountsDto> Accounts = new List<AccountsDto>();
    var linkedEmployees = Employees
                             .Select(e => 
                                 new LinkedEmployeesDto
                                      { EmpId = e.EmpId, 
                                        EmpName = e.EmpName,
                                        IsManager = Accounts
                                                   .First(a => a.EmpId == e.EmpId)
                                                   .IsManager
                                      })
                             .ToList();
