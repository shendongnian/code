    public class foo
    {
        public int x;
    }
    public struct bar
    {
        public int x;
    }
    public class MyClass
    {
        public static void Main()
        {
            foo a = new foo();
            bar b = new bar();
            
            a.x = 1;
            b.x = 1;
            
            foo a2 = a;
            bar b2 = b;
            
            a.x = 2;
            b.x = 2;
            
            Console.WriteLine( "a2.x == {0}", a2.x);
            Console.WriteLine( "b2.x == {0}", b2.x);
        }
    }
    
