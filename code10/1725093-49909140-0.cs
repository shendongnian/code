    public partial class Buzz
    {
    	public Buzz()
    	{ }
    
    	public Guid Id { get; set; }
    	public int TypeId1 { get; set; }
    	public int TypeId2 { get; set; }
    
    	public Fizz TypeId1Fizz { get; set; }
    	public Fizz TypeId2Fizz { get; set; }
    }
    
    
    public partial class Fizz
    {
    	public Fizz()
    	{ }
    
    	public int Id { get; set; }
    	public string Category { get; set; }
    	public string Value { get; set; }
    
    	public ICollection<Buzz> TypeId1Fizz { get; set; }
        public ICollection<Buzz> TypeId2Fizz { get; set; }
    }
