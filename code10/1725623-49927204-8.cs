	public class MyClass	
	{       
		public string Name { get; set; }
		
		public List<MyClass> Children { get; set; }
		
		public MyClass(string name)
		{
			Children = new List<MyClass>();
			Name = name;
		}       
        //Added a new constructor so we can pass an IEnumerable of children on creation
	    public MyClass(string name, IEnumerable<MyClass> children)
	    {
		    Children = new List<MyClass>(children);
		    Name = name;	       
	    }
    }
