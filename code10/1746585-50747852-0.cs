    class Class1
    {
        public override string ToString()
        {
            return "Class1";
        }
    }
     class Class2
        {
            public override string ToString()
            {
                return "Class2";
            }
        }
    class Program
        {
            static void Main(string[] args)
            {
                var cl1 = new Class1();
                var cl2 = new Class2();
                Test(cl1);
                Test(cl2);
            }
    
            static void Test(Object obj)
            {
                Console.WriteLine(obj.ToString());
                Console.Read();
            }
        }
