    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new Exception("exception thrown from try block");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Inner catch block handling {0}.", ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("Inner finally block");
                    throw new Exception("exception thrown from finally block");
                    Console.WriteLine("This line is never reached");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outer catch block handling {0}.", ex.Message);
            }
            finally
            {
                Console.WriteLine("Outer finally block");
            }
        }
    }
