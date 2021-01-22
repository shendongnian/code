    static void Main()
        {
            Console.WriteLine("Example 1: re-throw inside of another try block:");
            try
            {
                Console.WriteLine("--outer try");
                try
                {
                    Console.WriteLine("----inner try");
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("----inner catch");
                    throw;
                }
                finally
                {
                    Console.WriteLine("----inner finally");
                }
            }
            catch
            {
                Console.WriteLine("--outer catch");
                // swallow
            }
            finally
            {
                Console.WriteLine("--outer finally");
            }
            Console.WriteLine("Huzzah!");
            
            Console.WriteLine();
            Console.WriteLine("Example 2: re-throw outside of another try block:");
            try
            {
                Console.WriteLine("--try");
                throw new Exception();
            }
            catch
            {
                Console.WriteLine("--catch");
                throw;
            }
            finally
            {
                Console.WriteLine("--finally");
            }
            Console.ReadLine();
        }
