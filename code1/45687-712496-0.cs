    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        using System;
        using System.Reflection;
    
        namespace Test
        {
            class Generic<A, B>
            {
                public string Method(A a, B b)
                {
                    return a.ToString() + b.ToString();
                }
    
                public string Method(B b, A a)
                {
                    return b.ToString() + a.ToString();
                }
            }
    
            class Program
            {
                static void Main(string[] args)
                {
                    Generic<int, double> t1 = new Generic<int, double>();
                    Console.WriteLine(t1.Method(1.23, 1));
    
                    Generic<int, int> t2 = new Generic<int, int>();
                    // Following line gives:
                    //     The call is ambiguous between the following methods
                    //     or properties: 'Test.Generic<A,B>.Method(A, B)' and
                    //     'Test.Generic<A,B>.Method(B, A)'
                   MethodInfo [] methods = t2.GetType().GetMethods();
                    foreach(MethodInfo method in methods)
                    {
                        if (method.Name == "Method")
                        {
                            method.Invoke(t2,new Object[2] {1,2});
                            break;
                        }
                    }
                }
            }
        }
    }
