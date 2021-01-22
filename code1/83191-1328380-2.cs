    delegate string myDel(int s);
    public class Program
    {
        static string Func(myDel f)
        {
            return f(2);
        }
    
        public static void Main()
        {
            Test obj = new Test();
            myDel d = obj.func;
            Console.WriteLine(Func(d));
        }
    }
    class Test
    {
        public string func(int s)
        {
            return s.ToString();
        }
    }
