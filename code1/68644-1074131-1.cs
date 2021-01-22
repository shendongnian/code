    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MethodBase m = MethodInfo.GetCurrentMethod();
                MemberInfo info = (MemberInfo)m;
                Console.WriteLine(info.Name);
                Console.ReadKey();
            }
        }
    }
