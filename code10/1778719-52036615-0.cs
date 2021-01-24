    void Main()
    {
        var a = new BaseClass();
    
        var b = a as DerivedClass;
        if (b == null)
            Console.WriteLine("'a as Derived' Is NULL");
    }
    
    
    public class BaseClass
    {
    }
    
    public class DerivedClass : BaseClass
    {
    }
