    class nonStaticDLLCLASS
    {
       public event Event1;
    
       public CallStaticMethod()
      {
         StaticTestClass.GoStaticMethod(this);
      }
    }
    
    class StaticTestClass
    {
       public static GoStaticMethod(nonStaticDLLCLASS instance)
       {
         // Here I want to fire Event1 in the nonStaticDLLCLASS
         // I know the following line is not correct but can I do something like that?
    
         instance.Event1();
    
       }
    }
