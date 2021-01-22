	public class Thing<T>
	{
		public T Value { get; set; }
	}
	class ListOfString : List<string>
	{ }
	class Program
	{
		static void Main(string[] args)
		{
			var x = new Thing<ListOfString>();
			x.Value = new ListOfString();
			x.Process();
			x.Value.Add("asd");
			x.Process();
			//var x2 = new Thing<int>();
			// Error	1	The type 'int' cannot be used as type parameter 'T' 
			// in the generic type or method 
			// 'ThingExtensions.Process<T>(Thing<T>)'. 
			// There is no boxing conversion from 'int' to 
			// 'System.Collections.Generic.IEnumerable<string>'.	
			//x2.Process();
			Console.Read();
		}
	}
