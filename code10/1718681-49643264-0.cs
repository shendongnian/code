    List<EmployeesDto> Employees = new List<EmployeesDto>();            
            List<AccountsDto> Accounts = new List<AccountsDto>();           
            List<LinkedEmployeesDto> linkedEmployees = new List<LinkedEmployeesDto>();
            linkedEmployees = (from emp in Employees
                               join acc in Accounts
                                    on emp.EmpId equals acc.EmpId
                               select new LinkedEmployeesDto()
                               {
                                   EmpId = emp.EmpId,
                                   EmpName = emp.EmpName,
                                   IsManager = acc.IsManager
                               }).ToList();
