    public async Task<IEnumerable<EmployeeDto>> GetAll(){
        var employees = await getFromRepo.Employees();
    
        return employees.Select(x => new EmployeeDto{
            //...
            EmployeeId = x.EmpId //<--
            Status = await GetStatusNameAsync(x.EmpId) //<--
            //...
        }).GroupBy(x => x.EmployeeId)
        .Select(x => x.First)).ToList();
    }
