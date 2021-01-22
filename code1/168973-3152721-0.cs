    public class MyClass
    {
       public static void Foo()
       {
           Console.Write("Foo");
       }
    
       public void Bar()
       {
           Foo(); // Perfectly valid call
       }
    }
