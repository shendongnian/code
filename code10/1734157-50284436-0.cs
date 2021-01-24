	public static List<DataContractAttribute> GetDataContracts<T>()where T : class
	{
		return typeof(T).BaseType?
                        .GetCustomAttributes(false)
                        .OfType<DataContractAttribute>()
                        .ToList();
	}
	public static void Main()
	{
		var attribute = GetDataContracts<ProductViewModel>().FirstOrDefault();
		Console.WriteLine(attribute?.Name ?? "NoCigar");
	}
