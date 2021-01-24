    public abstract class A
    {
     // Some abstract stuff
    
     public static A CreateInstance(Type myType)
     {
       Type type = myType; // pseudo method
       return (A)Activator.CreateInstance(type);  
     }
    }
