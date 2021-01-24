	void Main()
	{
		var foo = new Foo()
		{
			Id = 1,
			Bar = new Bar { Message = "Message" }
		};
		
		var json = JsonConvert.SerializeObject(foo);
		var foo2 = JsonConvert.DeserializeObject<Foo>(json);
		
		//foo == foo2 here
	}
	
	public class Foo
	{
		public int Id { get; set; }
		public Bar Bar { get; set; }
	}
	
	public class Bar 
	{
		public string Message { get; set; }
	}
