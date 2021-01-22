    public class Test
    {
        public Test() : this("Called from default constructor") { }
        public Test(String msg)
        {
            Console.WriteLine(msg);
        }
    }
