    public class MyClass
    {
       IMyService _myService; 
    
       public MyClass()
       {
          _myService = new SomeConcreteService();    
       }
    }
