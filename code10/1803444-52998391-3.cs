    [Serializable]
    public abstract class Person
    {
      public string Name { get; set; }           
    }
    
    [Serializable]
    public class Employee : Person
    {            
      public decimal Salary { get; set; }
    }
