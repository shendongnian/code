    var qResult = from d in dba.Department
                  join e in dba.Employee d.DepartmentID equals e.DepartmentID into j1
                  select new
                  {
                      Department = d,
                      Employees = j1
                  };
    
    var result = from d in qResult.AsEnumerable()
                 select new DepartmentSummary()
                 {
                     Department = d.Department,
                     Employees = e.Employees.ToList()
                 };
