    using System;
    using System.Linq;
                        
    public class Program {
        public static void Main() {
            var prices = new int[] { 2, 2, 4, 3 };
            
            var map = prices.Select((value,index) => new { index, value});
            
            var lookUp = map.ToLookup(_ => _.value, _ => _.index);
            
            foreach(var item in lookUp) {
                var key = item.Key;	
                var values = string.Join(",",item);
                var output = String.Format("{0} - {1}",key,values);
                Console.WriteLine(output);
            }
        }
    }
    
