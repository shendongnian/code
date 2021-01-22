    public enum E
    {
        Zero = 0,
        One = 1,
    } 
    
    class A
    {
        public static A(string s, object o)
        { System.Console.WriteLine("{0} => A(object)", s); } 
    
        public static A(string s, E e)
        { System.Console.WriteLine("{0} => A(Enum E)", s); }
    
        static void Main()
        {
            A a1 = new A("0", 0);
            A a3 = new A("(int) E.Zero", (int) E.Zero);
        }
    }
