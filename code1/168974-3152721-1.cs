    public class MyClass
    {
       public static void Foo()
       {
           MyClass c = new MyClass();
           c.Bar();
       }
    
       public void Bar()
       {
           Console.Write("Foo");
       }
    }
