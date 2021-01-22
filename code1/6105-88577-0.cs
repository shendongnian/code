    using System;
    namespace StackOverflowMess
    {
        class Program
        {
            static void TestMethod()
            {
                throw new NotImplementedException();
            }
            static void Main(string[] args)
            {
                try
                {
                    //example showing the output of throw ex
                    try
                    {
                        TestMethod();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.WriteLine();
                Console.WriteLine();
                try
                {
                    //example showing the output of throw
                    try
                    {
                        TestMethod();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.ReadLine();
            }
        }
    }
