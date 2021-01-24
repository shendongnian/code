    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] hands = new[] {
            "8C TS KC 9H 4S 7D 2S 5D 3S AC",
            "2C TS KC 9H 4S 8D 2S 5D 3S AC",
            "3C TS KC 9H 4S 9D 2S 5D 3S AC",
            "4C TS KC 9H 4S 6D 2S 5D 3S AC",
            "5C TS KC 9H 4S 5D 2S 5D 3S AC",
            "6C TS KC 9H 4S 4D 2S 5D 3S AC",
            "9C TS KC 9H 4S 3D 2S 5D 3S AC",
            "7C TS KC 9H 4S 2D 2S 5D 3S AC",
            };
    
            var split = hands
                .Select(s => // select is used to split it in first 5 + second 5 using 
                    new      // IEnumeratble<T>.Take(5) and .Skip(5) after splitting
                    {        // string.Join glues the splits on " " back together
                        p1 = string.Join(" ", s.Split(" ".ToCharArray(),
                         StringSplitOptions.RemoveEmptyEntries).Take(5)).Trim(),
                        p2 = string.Join(" ", s.Split(" ".ToCharArray(),
                         StringSplitOptions.RemoveEmptyEntries).Skip(5)).Trim()
                    })
            .ToList();
    
            // I provided the stringsplit-options to get rid of "empty" splits on "   ".
            
            var p1 = split.Select(s => s.p1).ToArray();
            var p2 = split.Select(s => s.p2).ToArray();
    
            foreach (var t in p1)
                Console.WriteLine("P1:   " + t);
            Console.WriteLine();
            foreach (var t in p2)
                Console.WriteLine("P2:   " + t);
    
            Console.ReadLine();
        }
    }
