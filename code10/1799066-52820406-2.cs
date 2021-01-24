	public static void Main()
	{
		var str = "SD50MRF999";
		var digits = string.Concat(str.Reverse().TakeWhile(char.IsDigit).Reverse());
		var result = str.Remove(str.Length - digits.Length) + (int.Parse(digits) + 1);
		Console.WriteLine(result);
	}
