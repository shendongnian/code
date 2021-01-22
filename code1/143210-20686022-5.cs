    // Output:
    // 1 5
    // 2 0
    namespace ScrapCSConsole
    {
        using System;
    
        interface IMyTest
        {
            void MyTestMethod(int notOptional, int optional = 5);
        }
    
        class MyTest : IMyTest
        {
            public void MyTestMethod(int notOptional, int optional = 0)
            {
                Console.WriteLine(string.Format("{0} {1}", notOptional, optional));
            }
        }
    
        class Program
        {      
            static void Main(string[] args)
            {
                IMyTest myTest1 = new MyTest();
                myTest1.MyTestMethod(1);
    
                MyTest myTest2 = new MyTest();
                myTest2.MyTestMethod(2);
            }
        }   
    }
