    public class ClassA<T> where T : BaseClass
    {
       public T MyClass { get; set; }
    
       public ClassA(T myClass) { MyClass = myClass; }
    }
