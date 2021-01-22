    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
        static Dictionary<int, int> prices = new Dictionary<int, int> {
                { 1, 299 },
                { 5, 999 },
                { 10, 1899 },
                { 20, 3499 },
                { 50, 7999 }
        };
    
        class Bundle
        {
            public int Price;
            public Dictionary<int, int> Licenses;
        }
    
        Bundle getBestBundle(int n, Dictionary<int, int> prices)
        {
            Bundle[] best = new Bundle[n + prices.Keys.Max()];
            best[0] = new Bundle
            {
                Price = 0,
                Licenses = new Dictionary<int, int>()
            };
    
            for (int i = 1; i < best.Length; ++i)
            {
                best[i] = null;
                foreach (int amount in prices.Keys.Where(x => x <= i))
                {
                    Bundle bundle = new Bundle
                    {
                         Price = best[i - amount].Price + prices[amount],
                         Licenses = new Dictionary<int,int>(best[i - amount].Licenses)
                    };
    
                    int count = 0;
                    bundle.Licenses.TryGetValue(amount, out count);
                    bundle.Licenses[amount] = count + 1;
    
                    if (best[i] == null || best[i].Price > bundle.Price)
                    {
                        best[i] = bundle;
                    }
                }
            }
            return best.Skip(n).OrderBy(x => x.Price).First();
        }
    
        void printBreakdown(Bundle bundle)
        {
            foreach (var kvp in bundle.Licenses) {
                Console.WriteLine("{0,2} * {1,2} {2,-5} @ ${3,4} = ${4,6}",
                   kvp.Value,
                    kvp.Key,
                    kvp.Key == 1 ? "user" : "users",
                    prices[kvp.Key],
                    kvp.Value * prices[kvp.Key]);
            }
    
            int totalUsers = bundle.Licenses.Sum(kvp => kvp.Key * kvp.Value);
    
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,7} {1,-5}           ${2,6}",
                totalUsers,
                totalUsers == 1 ? "user" : "users",
                bundle.Price);
        }
    
        void Run()
        {
            Console.WriteLine("n = 136");
            Console.WriteLine();
            printBreakdown(getBestBundle(136, prices));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("n = 4");
            Console.WriteLine();
            printBreakdown(getBestBundle(4, prices));
        }
    
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
