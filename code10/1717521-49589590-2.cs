    using System;
    using System.Linq;
                        
    public class Program {
        public static void Main() {
            var prices = new int[] { 2, 2, 4, 3 };
            
            var map = prices.Select((value, index) => new { index, value });
            
            var lookUps = map.ToLookup(_ => _.value, _ => _.index);
            
            foreach(var item in lookUps) {
                var value = item.Key;
                var indexes = string.Join(",", item);
                var output = String.Format("{0} - {1}", value, indexes);
                Console.WriteLine(output);
            }
        }
    }
    
