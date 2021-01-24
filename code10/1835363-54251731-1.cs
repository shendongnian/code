    var data = new[] {
		new Dictionary<string, string> (){
			{"Name" , "ITWeiHan" }
		}
	};
    // calls wrong overload
	data.Execute(); //calls IEnumerable<T>
    // calls corrrect
	data.Execute<string, string>(); //calls IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>>
----------
    public static void Execute<TKey, TValue>(this IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>> enums)
	{
		Console.WriteLine("IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>>");
	}
	public static void Execute<T>(this IEnumerable<T> enums)
	{
		Console.WriteLine("IEnumerable<T>");
	}
