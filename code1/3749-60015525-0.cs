public string GetTypeName(object obj)
{
	return obj switch
	{
		int i => "Int32",
		string s => "String",
		{ } => "Unknown",
		_ => throw new ArgumentNullException(nameof(obj))
	};
}
As a result, you get:
Console.WriteLine(GetTypeName(obj: 1));           // Int32
Console.WriteLine(GetTypeName(obj: "string"));    // String
Console.WriteLine(GetTypeName(obj: 1.2));         // Unknown
Console.WriteLine(GetTypeName(obj: null));        // System.ArgumentNullException
You can read more about the new feature [here][1].
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
