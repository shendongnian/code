	class Solution
	{
		static void Main(string[] args)
		{
			string N = Console.ReadLine();
	
			var nums = N.TrimStart('[').TrimEnd(']').Split(',').Select(x => byte.Parse(x)).OrderBy(x => x);
	
			List<Range> ranges = new List<Range>();
			Range r = null;
			foreach (var num in nums)
			{
				if (ranges.Count == 0)
				{
					r = new Range(num);
					ranges.Add(r);
					continue;
				}
				if (r.TryAddRight(num)) continue;
	
				r = new Range(num);
				ranges.Add(r);
			}
	
			Console.WriteLine(String.Join(",", ranges));
		}
	}
