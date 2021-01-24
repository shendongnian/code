    public class Person
    {
        public string Name;
    
        public virtual void Update(Person person)
        {
            this.Name = person.Name;
        }
    }
    
    public class Employee : Person
    {
        public string Id;
    
        public virtual void Update(Employee employee)
        {
            base.Update(employee);
            this.Id = employee.Id;
        }
    }
    
    public class Manager: Employee
    {
        public string Title;
    
        public void Update(Manager manager)
        {
            base.Update(manager);
            this.Title = manager.Title;
        }
    }
