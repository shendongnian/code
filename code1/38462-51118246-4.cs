    public interface IShape
    {
    	string Name { get; set; }
    }
    
    public class NoShape : IShape
    {
    	public string Name { get; set; } = "I have No Shape";
    }
    
    public class Circle : IShape
    {
    	public string Name { get; set; } = "Circle";
    }
    
    public class Rectangle : IShape
    {
    	public Rectangle(string name)
    	{
    		this.Name = name;
    	}
    
    	public string Name { get; set; } = "Rectangle";
    }
    
