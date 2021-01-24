    public static IEnumerable<DTO.Employee> GetDefaultMgr(string EMPID)
    {
        IEnumerable<DTO.Employee> manager = EmpCache.EmployeeList
                .Where(s => s.EmpID.ToLower() == EMPID.ToLower())
                .GroupBy(x => x.MgrID)
        .Select(x => x.FirstOrDefault()).ToList();
    
         return manager; //<- "Enumeration yielded no results"
    }
