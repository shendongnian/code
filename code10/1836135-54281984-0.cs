    public static IEnumerable<DTO.Employee> GetDefaultMgr(string EMPID)
     {
      IEnumerable<DTO.Employee> manager = EmpCache.EmployeeList
                .Where(s => s.EmpID == EMPID)
                 .GroupBy(x => x.MgrID)
                 ?.Select(x => x.FirstOrDefault());
            // ? is for that if there is no data then dont do the select operation
            return manager; //<- "Enumeration yielded no results"
        }
