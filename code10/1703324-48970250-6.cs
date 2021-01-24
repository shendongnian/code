    public class A
    {
        private reandonly String _var;
        public String Var
        {
            get { return _var; }
        }
        public A(String var)
        {
            _var = var;
        }
    }
    public static class B
    {
        public static void DoSomething(String text)
        {
            Console.Writeline(text);
        }
    }
    
    public class C
    {
        public static void Main(string args[])
        {
            A a = new A("name");
            B.DoSomething(a.Var);
        }
    }
