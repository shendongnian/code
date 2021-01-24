	public class Foo
	{
		private class MyException : Exception
		{
			public MyException(string message) : base(message) { }
		}
		public static void Throw()
		{
			throw new MyException("Hello world.");
		}
	}
	public class Program
	{
		public static void Main()
		{
			try
			{
				Foo.Throw();
			}
			catch(System.Exception exception)
			{
				Console.WriteLine
			    (
					"Exception is of type '{0}' with a message of '{1}'", 
					exception.GetType().Name, 
					exception.Message
				);
				//Does not compile:
				//var typedException = (Foo.MyException)exception;  
			}
		}
	}
