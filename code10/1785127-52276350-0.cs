    public class Person
	{
	    public string Name { get; set; }
		
		public static implicit operator Person(string name) =>
            new Person { Name = name };	
	}
