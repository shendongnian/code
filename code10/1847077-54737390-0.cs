    public class ClassFactory: IClassFactory
    {
        public MyClass Create()
        {
             if (some condition)
                  return new MyClass1;
             return new MyClass2;
        }
    }
    
    class MyClass
    {
        protected string CommonLogic()
        {
             //common logic 
             return string;
        }
    
    }
    
    class MyClass1 : MyClass
    {
        public object SpecificMethod()
        {
            CommonLogic();
            .....
        }
    
    }
    
    class MyClass2 : MyClass
    {
        public object SpecificMethod2()
        {
            CommonLogic();
            .....
        }
    }
