	public static List<DataContractAttribute> GetDataContracts<T>()where T : class
	{
		return typeof(T).GetTypeInfo()
                        .GetCustomAttributes(false)
                        .OfType<DataContractAttribute>()
                        .ToList();
	}
