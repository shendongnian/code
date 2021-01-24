    var allDepartmentEmployeesEntities = dbContext.DepartmentEmployeesEntity.ToArray();
    foreach (var departmentEmployee in allDepartmentEmployeesEntities) {
       foreach(var employee in departmentEmployee.Employees) {
          if (entitiesByEmployee.ContainsKey(employee)) {
              // this employee already showed up in another department, update his entry
              entitiesByEmployee[employee].Departments.Add(departmentEmployee.Department)
          }
          else {
              // this employee has not been processed yet, create new entry
              var newEntry = new EmployeeDepartmentsEntity {
                  Employee = employee,
                  Departments = new List<DepartmentEntity> {departmentEmployee.Department}
              };
              entitiesByEmployee.Add(employee, newEntry);
          }
       }
    }
