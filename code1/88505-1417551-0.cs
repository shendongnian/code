    //Level1
    public abstract class Employee
    {
    public string Name{get;set;}
    public abstract double CalculateSalary();
    
    }
    
    //Level2
    public abstract class CalssAEmployee:Employee
    {
    public int NumberOfWorkingHours{get;set;}
    
    }
    
    public abstract class ClassBEmployee:Employee
    {
    public int NumberOfSales{get;set;}
    }
