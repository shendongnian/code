    using System;
    
    class Test
    {
        static void Main()
        {
            try
            {
                ThrowException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    
        static void ThrowException()
        {
            
            try
            {
                ThrowException2();
            }
            catch (Exception e)
            {
                throw new Exception("Outer", e);
            }
        }
    
        static void ThrowException2()
        {
            throw new Exception("Inner");
        }
    }
