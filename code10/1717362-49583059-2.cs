    using System.Threading.Tasks; 
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public async static void Main()
        {
            // create a dictionary of 10 tasks
            var tasks = Enumerable.Range(0, 10)
                .ToDictionary(i => i, i => Task.FromResult(i * i));
    
            // await all their results
    		// mapping to a collection of KeyValuePairs
            var pairs = await Task.WhenAll(
    			tasks.Select(
    				async pair => 
    					new KeyValuePair<int, int>(pair.Key, await pair.Value)));
    		
    		var dictionary = pairs.ToDictionary(p => p.Key);
    		
    		System.Console.WriteLine(dictionary[2].Value); // 4
        }
    }
