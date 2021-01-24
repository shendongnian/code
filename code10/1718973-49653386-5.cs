	public class Program
	{
		public static void Main()
		{
			ItemBase itemBase = new Hammer();
			Console.WriteLine(itemBase.Name);
			itemBase.Name = "Foo";
			Console.WriteLine(itemBase.Name);
		}
	}
	
