    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace TestGlobalMethod
    {
    class Program
    {
        static void Main(string[] args)
        {
            
            Assembly
                .Load("globalmethods")
                .GetLoadedModules()[0]
                .GetMethod("IAmAGlobalMethod")
                .Invoke(null,null);
            Console.ReadKey();
        }
    }
