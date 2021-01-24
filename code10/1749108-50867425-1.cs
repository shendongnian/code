    RelEmployeeDepartments
       .Where (
          red1 => 
                (RelEmployeeDepartments
                   .GroupBy (
                      red => 
                         new  
                         {
                            EmpID = red.EmpID
                         }
                   )
                   .Where (g => (g.Count (p => ((Int32?)(p.DeptID) != null)) == list1.Count ()))
                   .Select (
                      g => 
                         new  
                         {
                            EmpID = g.Key.EmpID
                         }
                   )
                   .Contains (
                      new  
                      {
                         EmpID = red1.EmpID
                      }
                   ) && 
                   list1.Contains (red1.DeptID)
                )
       )
       .GroupBy (
          red1 => 
             new  
             {
                EmpID = red1.EmpID
             }
       )
       .Where (g => (g.Count (p => ((Int32?)(p.DeptID) != null)) == list1.Count ()))
       .Select (
          g => 
             new  
             {
                EmpID = g.Key.EmpID
             }
       );
