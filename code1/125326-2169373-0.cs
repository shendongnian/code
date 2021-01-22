    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, 
        AllowMultiple = true)] 
    public class MyCustomAttribute : Attribute
    {
       Type type;
    
       public MyCustomAttribute(Type type)
       {
          this.type = type;
       }
    }
