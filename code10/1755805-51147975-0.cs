    public class A
    {
    	public int Id { get; set; }
    	//another properties
    
    	public virtual B B1 { get; set; }
    	public int B1Id { get; set; }
    
    	public virtual B B2 { get; set; }
    	public int B2Id { get; set; }
    
    	public virtual B B3 { get; set; }
    	public int B3Id { get; set; }
    }
    
    public class B
    {
    	public int Id { get; set; }
    	//another properties
    	
    	[InverseProperty(B1)]
    	public virtual ICollection<A> A1 { get; set; }
    	[InverseProperty(B2)]
    	public virtual ICollection<A> A2 { get; set; }
    	[InverseProperty(B3)]
    	public virtual ICollection<A> A3 { get; set; }
    }
