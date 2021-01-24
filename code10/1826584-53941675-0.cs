    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                {
    				foreach (var b in a.GetTypes())
    				{
    					Console.WriteLine(b.FullName);
    				}
    			}
            }
        }
    }
