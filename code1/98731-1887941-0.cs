    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ProvaException
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int a = doWithException<int>(divide, 0, typeof(DivideByZeroException), x => 300);
                Console.WriteLine(a);
                Console.ReadKey();
            }
    
            public static int divide(int b)
            {
                return 10 / b;
            }
    
            public static T doWithException<T>(Func<T, T> a, T param1, Type exType, Func<Exception, T> handFunction) {
                try
                {
                    return a(param1);
                }
                catch(Exception ex) {
                    if(exType.Equals(ex.GetType())) {
                         return handFunction(ex);
                    }
                    else 
                        throw ex;
                }
            }
        }
    }
