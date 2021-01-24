    using System;
    using System.Collections.Generic;
    using System.Data; 
    using System.Linq; 
    
    namespace ConsoleApp
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // dictionary containing the to be replaced Guids as key and the 
                // new ones as its values:
                var d = new Dictionary<string, string>
                {
                    ["e77f75b7-2373-dc11-8f13-0019bb2ca0a0"] = 
                              "1fe8f3fhhhhhhhhhhhhhhhhhhhhhhe811-80d8-00155d5ce473",
                    ["fbd0c892-2373-dc11-8f13-0019bb2ca0a0"] = 
                              "1fe8f3fhhhhhhhhhhhhhhhhhhhhhhe811-80d8-00155d5ce473",
                    ["76cd4297-1e31-dc11-95d8-0019bb2ca0a0"] =  
                             "eb892fbhhhhhhhhhhhhhhhhhhhhhhe811-80d8-00155d5ce473",
                    ["cd42bb68-2073-dc11-8f13-0019bb2ca0a0"] =  
                             "dc6077ehhhhhhhhhhhhhhhhhhhhhhe811-80d8-00155d5ce473",
                    ["96b97150-cd45-e111-a3d5-00155d10010f"] =  
                             "1fe8f3fhhhhhhhhhhhhhhhhhhhhhhe811-80d8-00155d5ce473",
                };
    
                var arr = Enumerable
                    .Range(1, 20)
                    .Select(i => Guid.NewGuid().ToString())
                    .Concat(d.Keys)
                    .OrderBy(t => Guid.NewGuid().GetHashCode()) // mix em
                    .ToArray();
