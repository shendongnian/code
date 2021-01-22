    void Main()
    {
     var a = new MyClass<string>();
     var b = new MyClass<int>();
     var c = new List<MyBase>();
     c.Add(a);
     c.Add(b);
    
    }
    
    public class MyBase { }
    // Define other methods and classes here
    public class MyClass<T> : MyBase {
    public T Value { get; set;}
    }
