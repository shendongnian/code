    List<EmployeesDto> lstEmployeesDto = new List<EmployeesDto>();
            List<AccountsDto> lstAccountsDto = new List<AccountsDto>();
            var result = lstEmployeesDto.Join(lstAccountsDto,
                                       e => e.EmpId,
                                       d => d.EmpId, (employee, account) => new
                                       {
                                           EmpId = employee.EmpId,
                                           EmpName = employee.EmpName,
                                           IsManager = account.IsManager
                                       });
