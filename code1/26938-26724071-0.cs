    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Dictionaries
    {
        class Greek
        {
    
            public static readonly string Alpha = "Alpha";
            public static readonly string Beta = "Beta";
            public static readonly string Gamma = "Gamma";
            public static readonly string Delta = "Delta";
     
    
            private static readonly BiDictionary<int, string> Dictionary = new BiDictionary<int, string>();
    
    
            static Greek() {
                Dictionary.Add(1, Alpha);
                Dictionary.Add(2, Beta);
                Dictionary.Add(3, Gamma);
                Dictionary.Add(4, Delta);
            }
    
            public static string getById(int id){
                return Dictionary.GetByFirst(id);
            }
    
            public static int getByValue(string value)
            {
                return Dictionary.GetBySecond(value);
            }
    
        }
    }
