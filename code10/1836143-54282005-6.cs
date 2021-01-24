     public static IEnumerable<DTO.Employee> GetDefaultMgr(string EMPID)
     {
                   IEnumerable<DTO.Employee> manager = 
                   from mng in EmpCache.EmployeeList
                    where mng.EmpID.ToLower() == EMPID.ToLower()
                    orderby mng.MgrID
                    select mng;
                   return manager;
        }
