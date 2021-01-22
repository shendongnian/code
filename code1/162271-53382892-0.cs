    using System;
    using System.Collections.Generic;
    
    namespace ExceptionDemo
    {
       class Program
       {
          static void Main(string[] args)
          {
             void fail()
             {
                (null as string).Trim();
             }
    
             void bareThrow()
             {
                try
                {
                   fail();
                }
                catch (Exception e)
                {
                   throw;
                }
             }
    
             void rethrow()
             {
                try
                {
                   fail();
                }
                catch (Exception e)
                {
                   throw e;
                }
             }
    
             void innerThrow()
             {
                try
                {
                   fail();
                }
                catch (Exception e)
                {
                   throw new Exception("outer", e);
                }
             }
    
             var cases = new Dictionary<string, Action>()
             {
                { "Bare Throw:", bareThrow },
                { "Rethrow", rethrow },
                { "Inner Throw", innerThrow }
             };
    
             foreach (var c in cases)
             {
                Console.WriteLine(c.Key);
                Console.WriteLine(new string('-', 40));
                try
                {
                   c.Value();
                } catch (Exception e)
                {
                   Console.WriteLine(e.ToString());
                }
             }
          }
       }
    }
