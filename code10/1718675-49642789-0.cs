    List<EmployeesDto> Employees = new List<EmployeesDto>();
    List<AccountsDto> Accounts = new List<AccountsDto>();
    var linkedEmployees = Employees.Select(e =>
            {
                
                return new LinkedEmployeesDto { EmpId = e.EmpId, EmpName = e.EmpName,
                    IsManager = Accounts.FirstOrDefault(a => a.EmpId == e.EmpId).IsManager };
            }
            ).ToList();
