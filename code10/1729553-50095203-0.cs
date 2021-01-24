	void Main()
	{
		MyFunction(typeof(Foo));
	}
	
	void MyFunction(Type someType)
	{
		var method =
			this
				.GetType()
				.GetMethod(
					"CallFunction",
					BindingFlags.Instance | BindingFlags.NonPublic)
				.MakeGenericMethod(someType);
		
		method.Invoke(this, null);
	}
	
	void CallFunction<T>()
	{
	    Console.WriteLine(typeof(T).Name);
	}
	
	public class Foo { }
