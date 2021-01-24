    public Task<string> GetStatusNameAsync(int empId) {
        return myRepo.GetStatus()
            .Where(x=>x.EmpId == empId)
            .Select(x => x.status)
            .FirstOrDefaultAsync();
    }
