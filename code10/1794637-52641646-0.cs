    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static Dictionary<string,int> Values {get;set;}
        
        static void Main()
        {
            Values = new Dictionary<string,int>();
            Values["Li"] = 1;
            Values["H"] = 1;
            
            Click("Li");
            Click("H");
        }
        
        static void Click(string element)
        {
            Values[element]++;
            
            DisplayElements();
        }
        
        static void DisplayElements()
        {
            foreach(var v in Values)
            {
                Console.WriteLine(v.Key + v.Value);
            }
        }
    }
