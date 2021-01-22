    class stackTest
    {
        public void Test()
        {
            StackFrame sFrame = new StackFrame(1);
            if (sFrame == null)
            {
                Console.WriteLine("sFrame is null");
                return;
            }
            var method = sFrame.GetMethod();
            if (method == null)
            {
                Console.WriteLine("method is null");
                return;
            }
            Type declaringType = method.DeclaringType;
            Console.WriteLine(declaringType.Name);
        }
        public void Test2()
        {
            Console.WriteLine(new StackFrame(1).GetMethod().DeclaringType.Name);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            stackTest s = new stackTest();
            s.Test();
            Console.WriteLine("Doing Test2");
            s.Test2();
            Console.ReadLine();
        }
    }
