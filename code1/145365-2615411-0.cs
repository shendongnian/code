    using System;
    using System.Linq;
    
    namespace FunctionCaller
    {
        class Demo2
        {
            private class data { }
    
            public void CallFunctions()
            {
                var funcs = new Func<string, data, string>[] { 
                    fn1, fn2, fn3
                };
    
                data d = new data();
    
                string sz1 = "Start";
    
                string result = funcs.Aggregate(
                    sz1,
                    (sz, x) => x(sz, d)
                );
    
                Console.WriteLine(result);
            }
    
            string fn1(string sz, data d)
            {
                return sz + "\r\nfn1";
            }
    
    
            string fn2(string sz, data d)
            {
                return sz + "\r\nfn2";
            }
    
            string fn3(string sz, data d)
            {
                return sz + "\r\nfn3";
            }
        }
    }
