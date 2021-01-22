    using System.Collection.ObjectModel;
    
    public Collection<Employee> GetEmployee(int id)
    {
               return new Collection<Employee>( 
                   (from e in MyDataContext.Employees
                         select new Employee()
                         {
                           e.empId = id
                         }
                    ).ToList() as IList<Employee>
               );
    }
