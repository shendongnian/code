    public class Person
    {
    	public string Name { get; set; }
    	public double Height { get; set; }
    	public DateTime DoB { get; set; }
    
    
    	public Person(string name, double height, DateTime dob) : this(name, height)
    	{
    		this.DoB = dob;
    	}
    
    	public Person(string name, double height)
    	{
    		this.Name = name;
    		this.Height = height;
    		this.DoB = DateTime.Now.Date;
    	}
    }
