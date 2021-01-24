    public class MyClass
    {
       private Foo _foo1;
    
       public Foo Foo1
       {
          get => _foo1;
          set => _foo1 = value;
       }
    
       public ref Foo ModifyMyClass()
       {
          return ref _foo1;
       }
    }
