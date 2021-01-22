    class Program
    {
        static void Main(string[] args)
        {
            var a = new A<B, B>();
            string tc = "Hi!";
            a.DoIt(tc);
        }
    }
    
    static class Ext
    {
        public static A<TA, TB> DoIt<TA, TB, TC>(this A<TA, TB> a, TC c)
        {
            return a;
        }
    }
    
    class A<TA, TB> { }
    class B { }
