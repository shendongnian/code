     public static IEnumerable<DTO.Employee> GetDefaultMgr(string EMPID)
     {
                   IEnumerable<DTO.Employee> manager = 
                   from mng in EmpCache.EmployeeList
                    where mng.EmpID == EMPID
                    orderby mng.MgrID
                    select mng;
                   return manager;
        }
