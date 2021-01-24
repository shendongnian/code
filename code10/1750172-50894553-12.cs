    class Program
    {
    	static void Main(string[] args)
    	{
    		var conf = ManualConfig.Create(DefaultConfig.Instance);
    		var summary = BenchmarkRunner.Run<DuplicateFindBench>(conf);
    	}
    }
    
    public class DuplicateFindBench
    {
    	[Benchmark]
    	[ArgumentsSource(nameof(Data))]
    	public List<string> GroupBy(string[] input, string description)
    	{
    		return input.GroupBy(x => x)
    							.Where(g => g.Count() > 1)
    							.Select(y => y.Key)
    							.ToList();
    	}
    
    	[Benchmark]
    	[ArgumentsSource(nameof(Data))]
    	public List<string> HashSet(string[] input, string description)
    	{
    		return GetDuplicates(input).Distinct().ToList();
    	}
	    [Benchmark]
	    [ArgumentsSource(nameof(Data))]
	    public List<string> Dict(string[] input, string description)
	    {
		    return GetDistinctDuplicates(input).ToList();
	    }
    
    	public static IEnumerable<string> GetDuplicates(IEnumerable<string> original)
    	{
    		var hs = new HashSet<string>();
    		foreach (var item in original)
    		{
    			if (!hs.Add(item))
    			{
    				yield return item;
    			}
    		}
    	}
		public static IEnumerable<string> GetDistinctDuplicates(IEnumerable<string> original)
		{
			var dict = new Dictionary<string, bool>();
			foreach (var s in original)
			{
				// If found duplicate 
				if (dict.TryGetValue(s, out var isReturnedDupl))
				{
					// If already returned
					if (isReturnedDupl)
					{
						continue;
					}
					dict[s] = true;
					yield return s;
				}
				else 
				{
					// First meet
					dict.Add(s, false);
				}
			}
		}
    
    	public IEnumerable<object[]> Data()
    	{
    		const int count1 = 1000;
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateNoDuplInput(count1).ToArray()), $"NoDupl, Count={count1}" };
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateAllDuplInput(count1).ToArray()), $"AllDupl, Count={count1}" };
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateRandomDuplInput(count1).ToArray()), $"RandomInput, Count={count1}" };
    
    		const int count2 = 10_000;
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateNoDuplInput(count2).ToArray()), $"NoDupl, Count={count2}" };
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateAllDuplInput(count2).ToArray()), $"AllDupl, Count={count2}" };
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateRandomDuplInput(count2).ToArray()), $"RandomInput, Count={count2}" };
    
    		const int count3 = 100_000;
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateNoDuplInput(count3).ToArray()), $"NoDupl, Count={count3}" };
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateAllDuplInput(count3).ToArray()), $"AllDupl, Count={count3}" };
    		yield return new object[] { ArrayParam<string>.ForPrimitives(CreateRandomDuplInput(count3).ToArray()), $"RandomInput, Count={count3}" };
    	}
    	
    	private const int RandomRange = 1000;
    	public List<string> CreateNoDuplInput(int inputSize)
    	{
    		var result = new List<string>();
    		for (int i = 0; i < inputSize; i++)
    		{
    			result.Add(i.ToString());
    		}
    
    		return result;
    	}
    	public List<string> CreateAllDuplInput(int inputSize)
    	{
    		var result = new List<string>();
    		for (int i = 0; i < inputSize; i++)
    		{
    			result.Add("duplicate value");
    		}
    
    		return result;
    	}
    	public List<string> CreateRandomDuplInput(int inputSize)
    	{
    		var r = new Random();
    		var result = new List<string>();
    		for (int i = 0; i < inputSize; i++)
    		{
    			result.Add(r.Next(0, RandomRange).ToString());
    		}
    
    		return result;
    	}
    }
