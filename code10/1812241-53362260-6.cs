	void Main()
	{
		bool condition = true;	
		var a = new ReferenceType<int>(1);
		var b = new ReferenceType<int>(2);
		var c = new ReferenceType<int>(3);
		
		(new []{b, a})[ConvertBoolToInt(condition)].Value = c.Value;
		Console.WriteLine($"a = {a}; b = {b}; c = {c}");	
	}
	//in C# bools aren't natively convertable to int as they are in many langauges, so we'd need to provide a conversion method
	public int ConvertBoolToInt(bool value)
	{
		return value ? 1 : 0;
	}
	//to allow us to change the value rather than only the refenence, we'd need to wrap our data in something and update the value assigned to its property
	public class ReferenceType<T>
	{
		public T Value {get;set;}
		public ReferenceType(T intValue)
		{
			Value = intValue;
		}
		public override string ToString()
		{
			return Value.ToString();
		}
	}
