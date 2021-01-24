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
            
            Click("Li"); // displays Li2 H1
            Click("H");  // displays Li2 H2
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
