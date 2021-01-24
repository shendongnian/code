    public async Task<IEnumerable<EmployeeDto>> GetAll(){
        var employees = await getFromRepo.Employees();
        var tasks = employees
            .GroupBy(_ => _.EmpId)
            .Select(async x => new EmployeeDto {
                EmployeeId = x.Key, //<--
                Status = await GetStatusNameAsync(x.Key), //<--
                //...
            }).ToArray();
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
