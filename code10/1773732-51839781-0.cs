    public class A<T> where T : C 
    {
        public T Obj { get; set; }
        public void DoStuff()
        {
            // Do stuff with Obj (C)
        }
    }
    public class B<T> : A<T> where T : D // this condition is valid since D inherits C
    {
        public T Obj { get; set; } 
        public void DoMoreStuff()
        {
            // Do stuff with Obj (D)
        }
    }
    public class C 
    {
        // ...
    }
    public class D : C
    {
        // ...
    }
