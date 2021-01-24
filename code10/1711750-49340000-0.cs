	using System;
	
	public class ExampleClass
	{
		public string text;
		public Action action;
	}
	
						
	public class Program
	{
		public static void Main()
		{
			var instance = new ExampleClass
			{
				text = "Hello"
			};
			instance.action = () => Console.WriteLine(instance.text);
			instance.action();
		}
	}
