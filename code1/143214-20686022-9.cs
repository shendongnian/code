    // Optput:
    // 2 5
    namespace ScrapCSConsole
    {
        using System;
    
        interface IMyTest
        {
            void MyTestMethod(int notOptional, int optional = 5);
        }
    
        class MyTest : IMyTest
        {
            public void MyTestMethod(int notOptional, int optional)
            {
                Console.WriteLine(string.Format("{0} {1}", notOptional, optional));
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyTest myTest1 = new MyTest();
                // The following line won't compile as it does not pass a required
                // parameter.
                //myTest1.MyTestMethod(1);
    
                IMyTest myTest2 = myTest1;
                myTest2.MyTestMethod(2);
            }
        }
    }
