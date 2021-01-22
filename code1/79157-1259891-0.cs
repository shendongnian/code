    public interface IEmployee
    {
        Int32 Id {get;}
        String Name {get;set;}
        // ... and so on ...
    }
    public class Employee: IEmployee
    {
        Int32 Id {get;set;}
        String Name {get;set;}
    }
