    using System;
    
    class OtherException : Exception {}
    
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Foo();
            }
            catch (OtherException)
            {
                Console.WriteLine("Caught OtherException");
            }
        }
    
        static void Foo()
        {
            try
            {
                string x = null;
                int y = x.Length;
            }
            catch (NullReferenceException)
            {
                throw new OtherException();
            }
            catch (Exception)
            {
                Console.WriteLine("Caught plain Exception");
            }
        }
    }
