    public class Employee
    {
       private readonly string _name;
    
       public string Name
       { 
          get
          {
             return _name;
          }
       }
    
       public Employee(string name)
       {
          _name = name;
       }
    }
