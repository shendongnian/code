    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApp1
    {
        class Program
        {
            private static Dictionary<string, Func<int, int, int>> FuncOps = new Dictionary<string, Func<int, int, int>>
            {
                {"add", (a, b) => a + b},
                {"subtract", (a, b) => a - b}
            };
            //There are no anonymous delegates
            //private static Dictionary<string, delegate> DelecateOps = new Dictionary<string, delegate>
            //{
            //    {"add", delegate {} }
            //};
            private static Dictionary<string, dynamic> DynamicOps = new Dictionary<string, dynamic>
            {
                {"add", new Func<int, int, int>((a, b) => a + b)},
                {"subtract", new Func<int, int, int>((a, b) => a - b)},
                {"inverse", new Func<int,  int>((a) => -a )} //Can't do this with Func
            };
            private static Dictionary<string, MethodInfo> ReflectionOps = new Dictionary<string, MethodInfo>
            {
                {"abs", typeof(Math).GetMethods().Single(m => m.Name == "Abs" && m.ReturnParameter.ParameterType == typeof(int))}
            };
            static void Main(string[] args)
            {
                Console.WriteLine(FuncOps["add"](3, 2));//5
                Console.WriteLine(FuncOps["subtract"](3, 2));//1
                Console.WriteLine(DynamicOps["add"](3, 2));//5
                Console.WriteLine(DynamicOps["subtract"](3, 2));//1
                Console.WriteLine(DynamicOps["inverse"](3));//-3
                Console.WriteLine(ReflectionOps["abs"].Invoke(null, new object[] { -1 }));//1
                Console.ReadLine();
            }
        }
    }
