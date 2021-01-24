    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static Dictionary<string, int> activities = new Dictionary<string, int>
        {
            { "running", 0 },
            { "fishing", 25 },
            { "sleeping", 25 },
            { "drinking", 50 }
        };
        
        static void Main(string[] args)
        {
            int sum = activities.Sum(a => a.Value);
            int rand = new Random().Next(sum);
            int total = -1;
            string activity = activities.SkipWhile(a => (total += a.Value) < rand).First().Key;
            Console.WriteLine(activity);
        }
    }
