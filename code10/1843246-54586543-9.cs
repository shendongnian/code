    public async Task<IEnumerable<EmployeeDto>> GetAll(){
        var employees = await getFromRepo.Employees();
        var tasks = employees.Select(async x => new EmployeeDto {
            //...
            EmployeeId = x.EmpId //<--
            Status = await GetStatusNameAsync(x.EmpId) //<--
            //...
        });
        var results = await Task.WhenAll(tasks);
        return results
            .GroupBy(x => x.EmployeeId)
            .Select(x => x.First)
            .ToList();
    }
