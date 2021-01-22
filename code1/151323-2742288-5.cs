    void Main()
    {
        typeof(Base).IsAssignableFrom(typeof(Derived)).Dump();
        typeof(Base).IsAssignableFrom(typeof(Base)).Dump();
        typeof(int[]).IsAssignableFrom(typeof(uint[])).Dump();
    }
    
    public class Base { }
    public class Derived : Base { }
