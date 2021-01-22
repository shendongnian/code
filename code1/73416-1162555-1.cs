    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        public interface ITest
        {
            int val {get; set; }
            List<ITest> Tests {get; set; }
        }
        public class Test1 : ITest
        {
            public int val { get; set; }
            public List<ITest> Tests {get; set; }
            public Test1()
            {
                Tests = new List<ITest>();
            }
        }
        public class Test2 : ITest
        {
            public int val { get; set; }
            public List<ITest> Tests {get; set; }
            public Test2()
            {
                Tests = new List<ITest>();
            }
        }
        public class Test3 : ITest
        {
            public int val { get; set; }
            public List<ITest> Tests {get; set; }
            public Test3()
            {
                Tests = new List<ITest>();
            }
        }
        public class Test4 : ITest
        {
            public int val { get; set; }
            public List<ITest> Tests {
                get { return new List<ITest>(); }
                set {} 
            }
        }
        class Program
        {
            public static int GetMinVal(ITest initialTest, out ITest testWithMinVal)
            {
                int minVal = initialTest.val;
                testWithMinVal = initialTest;
                foreach (ITest t in initialTest.Tests)
                {
                    if (t.val < minVal)
                    {
                        minVal = GetMinVal(t, out testWithMinVal);
                    }
                }
                return minVal;
            }
    
            static void Main(string[] args)
            {
                Random r = new Random();
                Test1 test = new Test1();
                test.val = r.Next(100);
                for (int i = 0; i < 5; i++)
                {
                    Test2 test2 = new Test2();
                    test2.val = r.Next(100);
                    for (int j = 0; j < 4; j++)
                    {
                        Test3 test3 = new Test3();
                        test3.val = r.Next(100);
                        for (int k = 0; k < 3; k++)
                        {
                            Test4 test4 = new Test4();
                            test4.val = r.Next(100);
                            test3.Tests.Add(test4);
                        }
                        test2.Tests.Add(test3);
                    }
                    test.Tests.Add(test2);
                }
                ITest testA;
                int minVal = GetMinVal(test, out testA);
                Console.WriteLine(minVal);
            }
        }
    }
