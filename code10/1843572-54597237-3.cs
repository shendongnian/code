    public abstract class Person : IInformable
	{
		public string Name { get; set; }
		public void Info()
		{
			Console.WriteLine(Name); // for example
		}
	}
