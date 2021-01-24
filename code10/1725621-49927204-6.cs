	public class MyClass	
	{       
		public string Name { get; set; }
		
		public List<MyClass> Children { get; set; }
		
		public MyClass(string name)
		{
			Children = new List<MyClass>();
			Name = name;
		}       
        //Added a new constructor so we can pass a list of children on creation
	    public MyClass(string name, List<MyClass> children)
	    {
		    Children = children;
		    Name = name;	       
	    }
    }
