    var result = ent.MyTable                   // take MyTable
       .GroupBy(employee => new                // group all rows of this table into groups
       {                                       // with equal EmployeeId and EmployeeName
           Id = employee.EmployeeId,
           Name = employee.EmployeeName,
       })
       .Select(group => new                    // from every group make one object
       {                                       // with properties:
           EmployeeId = group.Key.Id,          // - the common employeeId
           EmployeeName = group.Key.Name       // - the common employeeName + the string value 
               + group.Count().ToString(),     //   of the number of elements in the group
       });
