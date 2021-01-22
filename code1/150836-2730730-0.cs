    public class Employee
    {
    
     private string nameField;
     public string Name 
     { 
      get
      {
        return this.nameField;
      }
     }
     public Employee(string name)
     {
       this.nameField = name;
     }
