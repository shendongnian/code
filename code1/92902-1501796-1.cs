    public static object lockObject = new object();
    public class MyClass
    {    
        lock(lockObject) 
        {
          // DO COOL CODE STUFF. 
        }
    }
