    namespace ConsoleApplication1
    {
        using System;
    
        enum Values
        {
            Value1
        }
    
        class Program
        {
            static void Test()
            {
                try
                {
                    int a = 0;
                    int c = 12 / a;
                }
                catch (Exception ex)
                {
                    ex.Data.Add(Values.Value1, "hello world");
                    throw ex;
                }
            }
    
            static void Main(string[] args)
            {
                try
                {
                    Test();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Data[Values.Value1].ToString());
                }
    
                Console.ReadLine();
            }
        }
    }
