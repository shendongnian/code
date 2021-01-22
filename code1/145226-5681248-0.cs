    public partial class BasicModelDataContext : DataContext
    {
            partial void InsertEmployee(Employee instance)
            {
                instance.MyValue = "NEW VALUE";
                Employee.Insert(instance);
            }
    
            partial void UpdateEmployee(Employee instance)
            {
                 instance.MyValue = "NEW Update VALUE";
                 Employee.Update(instance);
            }
    }
