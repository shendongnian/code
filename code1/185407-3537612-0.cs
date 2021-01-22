    class MyClass // <- Reference type.
    {
       private MyClass _child = new MyClass();
    
       public MyClass GetChild()
       {
          return _child;
       }
    }
