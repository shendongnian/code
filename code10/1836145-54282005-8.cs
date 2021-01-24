     public static  string GetDefaultMgr(string EMPID)
        {
           string managerID = EmpCache.EmployeeList
                    .Where(s => s.EmpID.ToLower() == EMPID.ToLower())
                    .GroupBy(x => x.MgrID)
            .Select(x => x.MgrID).FirstOrDefault().ToString();
        
             return managerID; //<- "Enumeration yielded no results"
        }
 
