    from red1 in RelEmployeeDepartments
    where
     (from red in RelEmployeeDepartments group red by new {
       red.EmpID
      }
      into g where g.Count(p => p.DeptID != null) == list1.Count() select new {
       g.Key.EmpID
      }).Contains(new {
      EmpID = red1.EmpID
     }) &&
     (list1).Contains(red1.DeptID)
    group red1 by new {
     red1.EmpID
    }
    into g
    where g.Count(p => p.DeptID != null) == list1.Count()
    select new {
     g.Key.EmpID
    };
