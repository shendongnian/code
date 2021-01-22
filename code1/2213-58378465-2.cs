	public static string Ordinals1(this int number)
	{
		switch (number)
		{
			case int p when p % 100 == 11:
			case int q when q % 100 == 12:
			case int r when r % 100 == 13:
				return $"{number}th";
			case int p when number % 10 == 1:
				return $"{number}st";
			case int p when number % 10 == 2:
				return $"{number}nd";
			case int p when number % 10 == 3:
				return $"{number}rd";
			default:
				return $"{number}th";
		}
	}
and what makes this solution special? nothing but the fact that I'm adding some performance considerations for various other solutions
frankly I doubt performance really matters for this particular scenario (who really needs the ordinals of millions of numbers) but at least it surfaces some comparisons to be taken into account... 
> 1 million items for reference (your millage may vary based on machine specs of course)
>
> with pattern matching and divisions (this answer)
>
> ~622 ms 
> 
> with pattern matching and strings (this answer)
>
> ~1967 ms 
> 
> with two switches and divisions (accepted answer)
>
> ~637 ms
> 
> with one switch and divisions (another answer)
>
> ~725 ms
void Main()
{
	var timer = new Stopwatch();
	var numbers = Enumerable.Range(1, 1000000).ToList();
	// 1
	timer.Reset();
	timer.Start();
	var results1 = numbers.Select(p => p.Ordinals1()).ToList();
	timer.Stop();
	timer.Elapsed.TotalMilliseconds.Dump("with pattern matching and divisions");
	// 2
	timer.Reset();
	timer.Start();
	var results2 = numbers.Select(p => p.Ordinals2()).ToList();
	timer.Stop();
	timer.Elapsed.TotalMilliseconds.Dump("with pattern matching and strings");
	// 3
	timer.Reset();
	timer.Start();
	var results3 = numbers.Select(p => p.Ordinals3()).ToList();
	timer.Stop();
	timer.Elapsed.TotalMilliseconds.Dump("with two switches and divisons");
	
	// 4
	timer.Reset();
	timer.Start();
	var results4 = numbers.Select(p => p.Ordinals4()).ToList();
	timer.Stop();
	timer.Elapsed.TotalMilliseconds.Dump("with one switche and divisons");
}
public static class Extensions
{
	public static string Ordinals1(this int number)
	{
		switch (number)
		{
			case int p when p % 100 == 11:
			case int q when q % 100 == 12:
			case int r when r % 100 == 13:
				return $"{number}th";
			case int p when number % 10 == 1:
				return $"{number}st";
			case int p when number % 10 == 2:
				return $"{number}nd";
			case int p when number % 10 == 3:
				return $"{number}rd";
			default:
				return $"{number}th";
		}
	}
	public static string Ordinals2(this int number)
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
	public static string Ordinals3(this int number)
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
	public static string Ordinals4(this int number)
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
