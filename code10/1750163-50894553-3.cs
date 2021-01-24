 ini
BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-4710HQ CPU 2.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3101.0
  DefaultJob : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3101.0
1) No duplicates in input
|  Method | input |     Mean |     Error |    StdDev | TotalCycles/Op |
|-------- |------ |---------:|----------:|----------:|---------------:|
| GroupBy | -     | 220.7 ns | 4.2959 ns | 4.0184 ns |            512 |
| HashSet | -     | 169.6 ns | 0.6959 ns | 0.6169 ns |            378 |
2) All duplicates in input
|  Method | input |     Mean |     Error |    StdDev | TotalCycles/Op |
|-------- |------ |---------:|--_-------:|-_--------:|---------------:|
| GroupBy | -     | 220.0 ns |  2.283 ns |  2.135 ns |            513 |
| HashSet | -     | 175.1 ns |  1.779 ns |  1.577 ns |            412 |
3) Random input
|  Method | input |     Mean |     Error |    StdDev | TotalCycles/Op |
|-------- |------ |---------:|----------:|----------:|---------------:|
| GroupBy | -     | 225.4 ns |  4.470 ns |  4.181 ns |            555 |
| HashSet | -     | 170.9 ns |  1.376 ns |  1.149 ns |            394 |
Source
    class Program
    {
    	static void Main(string[] args)
    	{
    		var conf = ManualConfig.Create(DefaultConfig.Instance);
    		conf.Add(new HardwareCounter[] { HardwareCounter.TotalCycles });
    		
    		var summary = BenchmarkRunner.Run<DuplicateFindBench>(conf);
    	}
    }
    
    public class DuplicateFindBench
    {
    	[Benchmark]
    	[ArgumentsSource(nameof(NoDuplicatesData))]
    	//[ArgumentsSource(nameof(AllDuplicatesData))]
    	//[ArgumentsSource(nameof(RandomDuplicatesData))]
    	public List<string> GroupBy(List<string> input)
    	{
    		return input.GroupBy(x => x)
    							.Where(g => g.Count() > 1)
    							.Select(y => y.Key)
    							.ToList();
    	}
    
    	[Benchmark]
    	[ArgumentsSource(nameof(NoDuplicatesData))]
    	//[ArgumentsSource(nameof(AllDuplicatesData))]
    	//[ArgumentsSource(nameof(RandomDuplicatesData))]
    	public List<string> HashSet(List<string> input)
    	{
    		return GetDuplicates(input).Distinct().ToList();
    	}
    
    	public static IEnumerable<string> GetDuplicates(IEnumerable<string> original)
    	{
    		var hs = new HashSet<string>();
    		foreach (var item in original)
    			if (!hs.Add(item))
    				yield return item;
    	}
    
    	public IEnumerable<List<string>> NoDuplicatesData()
    	{
    		yield return CreateNoDuplInput();
    	}
    
    	public IEnumerable<List<string>> AllDuplicatesData()
    	{
    		yield return CreateAllDuplInput();
    	}
    
    	public IEnumerable<List<string>> RandomDuplicatesData()
    	{
    		yield return CreateRandomDuplInput();
    	}
    
    	private const int InputSize = 100_000;
    	private const int RandomRange = 1000;
    	public List<string> CreateNoDuplInput()
    	{
    		var result = new List<string>();
    		for (int i = 0; i < InputSize; i++)
    		{
    			result.Add(i.ToString());
    		}
    		
    		return result;
    	}
    	public List<string> CreateAllDuplInput()
    	{
    		var result = new List<string>();
    		for (int i = 0; i < InputSize; i++)
    		{
    			result.Add("duplicate value");
    		}
    		
    		return result;
    	}
    
    	public List<string> CreateRandomDuplInput()
    	{
    		var r = new Random();
    		var result = new List<string>();
    		for (int i = 0; i < InputSize; i++)
    		{
    			result.Add(r.Next(0, RandomRange).ToString());
    		}
    		
    		return result;
    	}
    }
  [1]: https://github.com/dotnet/BenchmarkDotNet
