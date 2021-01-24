    var departments = from d in dataTable.AsEnumerable()
                      group d by new { d.Field<int32>("DeptId"), d.Field<string>("DeptName") } 
                      into g
                      select new
                      {
                          departmentId = g.Key.DeptId,
                          department = g.Key.DeptName
                      }).ToList();
