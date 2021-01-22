    public static void RunSnippet()
	{
		var c = new GenericClass<SomeType>();
	}
	
	public class GenericClass<T> where T : SomeType, new()
	{
		public GenericClass(){
			(new T()).functionA();
		}	
	}
	
	public class SomeType
	{
		public void functionA()
		{
			//do something here
			Console.WriteLine("I wrote this");
		}
	}
