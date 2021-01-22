    public class Base
    {
    }
    public class Subclass : Base
    {
        
    }
    //In your client-code
    Subclass subclass = new Subclass();
    string className = subclass.GetType().Name;
