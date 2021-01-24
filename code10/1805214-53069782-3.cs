    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp29
    {
        class Program
        {
    
            public static dynamic Vars = new System.Dynamic.ExpandoObject();
    
            static void AddorUpdateVar(string name, object value)
            {
                var vd = (IDictionary<string, object>)Vars;
                vd[name] = value;
            }
            static void Main(string[] args)
            {
    
                AddorUpdateVar("Hello", 213);
    
                var a1 = Vars.Hello;
    
                AddorUpdateVar("Hello", "World");
    
                var a2 = Vars.Hello;
    
                Vars.Hello = new int[] { 7, 3 };
    
                var a3 = Vars.Hello;
    
            }
        }
    }
       
