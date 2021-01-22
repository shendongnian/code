    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Inner catch block");
                    throw;
                }
                finally
                {
                    Console.WriteLine("Inner finally block");
                    throw new Exception();
                    Console.WriteLine("This line is never reached");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Outer catch block");
            }
            finally
            {
                Console.WriteLine("Outer finally block");
            }
        }
    }
