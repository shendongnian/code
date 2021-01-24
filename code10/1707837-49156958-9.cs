    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // c#7 inline func
            string[] CreateDemoData(Dictionary<string, string> replDict)
            {
                // c#7 inline func
                string FilText(string s) => $"Some text| that also incudes; {s} and more.";
    
                return Enumerable
                    .Range(1, 5)
                    .Select(i => FilText(Guid.NewGuid().ToString()))
                    .Concat(replDict.Keys.Select(k => FilText(k)))
                    .OrderBy(t => Guid.NewGuid().GetHashCode())
                    .ToArray();
            }
       
            // replacement dict
            var d = new Dictionary<string, string>
            {
                ["e77f75b7-2373-dc11-8f13-0019bb2ca0a0"] = "e77f75b7-replaced",
                ["fbd0c892-2373-dc11-8f13-0019bb2ca0a0"] = "fbd0c892-replaced",
                ["76cd4297-1e31-dc11-95d8-0019bb2ca0a0"] = "76cd4297-replaced",
                ["cd42bb68-2073-dc11-8f13-0019bb2ca0a0"] = "cd42bb68-replaced",
                ["96b97150-cd45-e111-a3d5-00155d10010f"] = "96b97150-replaced",
            };
    
            var arr = CreateDemoData(d);
    
