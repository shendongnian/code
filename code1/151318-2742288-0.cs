    void Main()
    {
        typeof(Derived).IsSubclassOf(typeof(Base)).Dump();
        typeof(Base).IsSubclassOf(typeof(Base)).Dump();
    }
    
    public class Base { }
    public class Derived : Base { }
