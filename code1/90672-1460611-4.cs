    public interface IFruit
    {
    	String name { get; set; }
    	Int32 id { get; set; }
    }
    
    public class Fruit : IFruit
    {
    	public String name { get; set; }
    	public Int32 id { get; set; }
    }
