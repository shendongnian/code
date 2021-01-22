    public class EmployeeCollection:BindingList<Employee>
        {
            public new void  Add(Employee emp)
            {
                base.Add(emp);
            }
    
            public void SaveToDB()
            {
               //code to save to db
            }
        }
