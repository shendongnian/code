    Columns = new List<Column<Employee>>{
                new Column<Employee> {
                    Key = "EmployeeId",   
                    SortExpression = new SortExpression<Employee>(e => e.EmployeeID)
                    // ... other irrelevant column properties ...  
                },
                new Column<Employee> {
                    Key = "EmployeeBirthDate",      
                    SortExpression = new SortExpression<Employee>(e => e.BirthDate)
                }
              };
