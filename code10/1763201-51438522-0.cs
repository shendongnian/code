    using System;
    using System.Collections.Generic;
    
    class WI
    {
        public string Data { get; private set; }
    
        public WI(string x)
        {
            Data = x;
        }
    }
    class Program
    {
        static public Dictionary<string, WI> Dict = new Dictionary<string, WI>();
        const string some_arg = "One";
        const string another_arg = "Two";
    
        static void Main(string[] args)
        {
            WI oWI = new WI(some_arg);
            string key = "mykey";
            if (!Dict.ContainsKey(key))
            {
                Dict.Add(key, oWI);
            }
    
            var before = Dict[key];
            Console.WriteLine($"Before: {before.Data}");
    
            oWI = new WI(another_arg);
    
            var after = Dict[key];
            Console.WriteLine($"After: {after.Data}");
        }
    }
