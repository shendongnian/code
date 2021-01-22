    class Program
    {
        static void Main(string[] args)
        {
            intTest it;
    
            it = new intTest();
    
            Console.ReadLine();
        }
    
        class intTest
        {
            int i;
    
            public intTest()
            {
                int i2;
    
                Console.WriteLine("i = " + i);
                Console.WriteLine("i2 = " + i2);
            }
        }
    }
