    using System;
    
    class Test
    {
        static void Main()
        {
            TestHandling(true);
            TestHandling(false);
        }
        
        static void TestHandling(bool throwFirst)
        {
            try
            {
                Child(throwFirst);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Previously caught? {ex.Data.Contains("Logged")}");
            }
        }
        
        
        static void Child(bool throwFirst)
        {
            try
            {
                if (throwFirst)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logging!");
                ex.Data["Logged"] = true;
                throw;
            }
            throw new Exception();
        }
    }
