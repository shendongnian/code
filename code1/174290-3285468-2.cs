    void Main()
    {
        Console.WriteLine(
            MyGenericMethod<Employee>()
                .GetGetMethod()
                    .Invoke(
                        new Employee {Name = "Bill"}, 
                        new object[] {}));
    }
    
    public class Employee : IEmployee {
        public string Name {get;set;} 
        string IEmployee.Name { get { throw new Exception(); } } 
    }
    public interface IEmployee {string Name {get;}}
    public PropertyInfo MyGenericMethod<T>() where T : IEmployee
    {
        return PropInfo((T e) => e.Name);
    }
