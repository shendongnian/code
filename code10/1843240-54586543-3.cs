    public async Task<IEnumerable<EmployeeDto>> GetAll(){
        var employees = await getFromRepo.Employees();
    
        return employees.Select(x=>new EmployeeDto{
            //...
            Status = await GetStatusNameAsync(x.EmpId) //<--
            //...
        }).GroupBy(x => x.EmpId)
        .Select(x => x.First)).ToList();
    }
