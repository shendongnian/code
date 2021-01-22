    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
    
            static int test = 0;
    
            static void MyMethod(int arg)
            {
                test += arg;
            }
            static void MyMethod(ref int arg)
            {
                test += arg;
            }
    
            static void MyMethod(Single arg)
            {
                test += Convert.ToInt32(arg);
            }
    
            static void MyMethod(ref Single arg)
            {
                test += Convert.ToInt32(arg);
            }
        }
    }
