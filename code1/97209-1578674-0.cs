    class MyBase
    {
       public MyBase()
       {
         // load the base class stuff.
       }
       int f1;
       int f2;
       int f3;
       int f4;
       int f5;
    }
    
    class MyClass2 : MyBase
    {
       public MyClass2() : base()
       {
         // load the MyClass2 f6
       }
    
       int f6;
    }
    
    class MyClass3 : MyBase
    {
       public MyClass3() : base()
       {
         // load the MyClass3 f7
       }
    
       int f7;
    }
