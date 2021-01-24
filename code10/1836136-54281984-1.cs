    public static IEnumerable<DTO.Employee> GetDefaultMgr(string EMPID)
     {
      IEnumerable<DTO.Employee> manager = EmpCache.EmployeeList
                .Where(s => s.EmpID == EMPID)
                 .GroupBy(x => x.MgrID);
               if(manager?.Count()>0)
                return manager.Select(x => x.First());
           return null;
        }
