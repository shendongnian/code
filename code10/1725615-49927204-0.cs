	public class MyClass	
	{       
		public string Name { get; set; }
		
		public List<MyClass> Children { get; set; }
		
		public MyClass(string name)
		{
			Children = new List<MyClass>();
			Name = name;
		}         
	}
