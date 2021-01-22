    // Optput:
    // 1 5
    namespace ScrapCSConsole
    {
        using System;
    
        interface IMyTest
        {
            void MyTestMethod(int notOptional, int optional = 5);
        }
    
        class MyTest : IMyTest
        {
            void IMyTest.MyTestMethod(int notOptional, int optional = 9)
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
                // The following line won't compile as MyTest method is not available
                // without first casting to IMyTest
                //myTest2.MyTestMethod(2);
            }
        }   
    }
