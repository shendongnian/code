    interface ISuperFoo
    {
        public ISuperFoo SomeMethod() { ... }
    }
    public class Foo : SuperFoo, ISuperFoo
    {
         // concrete implementation
         public Foo SomeMethod() { ... }
         // method for generic use, call by base type
         public ISuperFoo ISuperFoo.SomeMethod() 
         { 
           return SomeMethod(); 
         }
    }
    
    public void Processs()
    {
         ...
         foreach (var iSuperFoo in list)
         {
              ...
              iSuperFoo.SomeMethod();
         }
    }
