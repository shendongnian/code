    using System;
    using System.Threading.Tasks;				
    using System.Linq;
    
    public class Program
    {
    	public async static void Main()
    	{
            // create a dictionary of 10 tasks
    		var tasks = Enumerable.Range(0, 10)
                .ToDictionary(i => i, i => Task.FromResult(i));
    		
            // await all their results
            var results = await Task.WhenAll(
                tasks.Select(pair => pair.Value));
    		
            // The results are of type System.Int32
            Console.WriteLine(results.First().GetType());	
    	}
    }
