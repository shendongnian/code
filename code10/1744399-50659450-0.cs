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
                var g = SiteStructure.Instance(4);
            }
        }
        
        
        
        public sealed class SiteStructure { 
     public static SiteStructure Instance() 
     { return new SiteStructure();
     }
            public static SiteStructure Instance (int x)
            { return new SiteStructure (x);
            }
    
     SiteStructure() { }
    SiteStructure(int x) { Console.WriteLine("Hello"); }
        
        
    }
        
    }
