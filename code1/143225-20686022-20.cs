    // Output:
    // 1 0
    // 2 5
    // 3 7
    namespace ScrapCSConsole
    {
        using System;
    
        interface IMyTest
        {
            void MyTestMethod(int notOptional, int optional = 5);
        }
    
        interface IMyOtherTest
        {
            void MyTestMethod(int notOptional, int optional = 7);
        }
    
        class MyTest : IMyTest, IMyOtherTest
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
                MyTest myTest1 = new MyTest();
                myTest1.MyTestMethod(1);
    
                IMyTest myTest2 = myTest1;
                myTest2.MyTestMethod(2);
    
                IMyOtherTest myTest3 = myTest1;
                myTest3.MyTestMethod(3);
            }
        }
    }
