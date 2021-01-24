	public static void Main()
	{
		var input = "AL QADEER UR AL REHMAN AL KHALIL UN AAA BBB";
		Regex re = new Regex(@"\b\w{1,4}\b");
        var result = re.Replace(input, "");
		Console.WriteLine(result);
	}
