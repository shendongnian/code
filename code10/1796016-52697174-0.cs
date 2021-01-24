    class Employee : Person
        {
            public int ID { get; set; }
    
            public static bool operator ==(Employee employee, Employee employee2)
            {
                if (employee.ID == employee2.ID)
                    return true;
                else
                    return false;
    
                //but you should use 
                //return employee.ID == employee2.ID;
            }
    
            public static bool operator !=(Employee employee, Employee employee2)
            {
                return employee.ID != employee2.ID;
            }
    
            public override bool Equals(object obj)
            {
                var emp = obj as Employee;
                if (emp == null)
                    return false;
    
                return this.ID.Equals(emp.ID);
            }
        }
