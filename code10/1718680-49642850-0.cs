        List<EmployeesDto> employees = new List<EmployeesDto>();
        employees.Add(new EmployeesDto { EmpId = 1, EmpName = "1" });
        employees.Add(new EmployeesDto { EmpId = 2, EmpName = "2" });
        employees.Add(new EmployeesDto { EmpId = 3, EmpName = "3" });
        employees.Add(new EmployeesDto { EmpId = 4, EmpName = "4" });
        List<AccountsDto> accounts = new List<AccountsDto>();
        accounts.Add(new AccountsDto { EmpId = 1, IsManager = true });
        accounts.Add(new AccountsDto { EmpId = 2, IsManager = true });
        // To get only those records which are in accounts list
        IEnumerable<LinkedEmployeesDto> linkedEmployees = employees.Join(accounts,
                                                                         employee => employee.EmpId,
                                                                         account => account.EmpId,
                                                                         (employee, account) => new LinkedEmployeesDto
                                                                         {
                                                                             EmpId = employee.EmpId,
                                                                             EmpName = employee.EmpName,
                                                                             IsManager = account.IsManager
                                                                         });
        // To get all the records from employee and set IsManager as false if record no in accounts list
        linkedEmployees = from employee in employees
                          join account in accounts on employee.EmpId equals account.EmpId into holder
                          from acc in holder.DefaultIfEmpty()
                          select new LinkedEmployeesDto
                          {
                              EmpId = employee.EmpId,
                              EmpName = employee.EmpName,
                              IsManager = (acc == null) ? false : acc.IsManager
                          };
