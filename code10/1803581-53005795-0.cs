    public class Member
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public double salary { get; set; }
    }
    
    public class Player : Member
    {
    	public double? bonus { get; set; }
    }
