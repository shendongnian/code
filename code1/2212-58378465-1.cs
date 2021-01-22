void Main()
{
	var timer = new Stopwatch();
	var numbers = Enumerable.Range(1, 1000000).ToList();
	// 1
	timer.Reset();
	timer.Start();
	var results1 = numbers.Select(p => p.Format1()).ToList();
	timer.Stop();
	timer.Elapsed.Dump("with pattern matching");
	// 2
	timer.Reset();
	timer.Start();
	var results2 = numbers.Select(p => p.Format2()).ToList();
	timer.Stop();
	timer.Elapsed.Dump("with rest switches");
	// 3
	timer.Reset();
	timer.Start();
	var results3 = numbers.Select(p => p.Format3()).ToList();
	timer.Stop();
	timer.Elapsed.Dump("with rest divisions");
}
public static class Extensions
{
	public static string Format1(this int number)
	{
		var text = number.ToString();
		switch (text)
		{
			case string p when p.EndsWith("11"):
				return $"{number}th";
			case string p when p.EndsWith("12"):
				return $"{number}th";
			case string p when p.EndsWith("13"):
				return $"{number}th";
			case string p when p.EndsWith("1"):
				return $"{number}st";
			case string p when p.EndsWith("2"):
				return $"{number}nd";
			case string p when p.EndsWith("3"):
				return $"{number}rd";
			default:
				return $"{number}th";
		}
	}
	public static string Format2(this int number)
	{
		switch (number % 100)
		{
			case 11:
			case 12:
			case 13:
				return $"{number}th";
		}
		switch (number % 10)
		{
			case 1:
				return $"{number}st";
			case 2:
				return $"{number}nd";
			case 3:
				return $"{number}rd";
			default:
				return $"{number}th";
		}
	}
	public static string Format3(this int number)
	{
		var ones = number % 10;
		var tens = Math.Floor(number / 10f) % 10;
		if (tens == 1)
		{
			return $"{number}th";
		}
		switch (ones)
		{
			case 1:
				return $"{number}th";
			case 2:
				return $"{number}nd";
			case 3:
				return $"{number}rd";
			default:
				return $"{number}th";
		}
	}
}
