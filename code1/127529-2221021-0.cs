    public class Manager:Itest { ... }
    
    class Employee:Itest { ... }
    
    static void ShowSomething(Itest test)
    {
       test.DoSomething();
    }
        
    static void Main(string[] args)
    {
    
        Manager m = new Manager();            
        Employee e = new Employee();
    
        ShowSomething(m);
        ShowSomething(e);
    }
