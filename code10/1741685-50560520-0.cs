    public class A
    {
        public A()
        {
            nameA = string.Empty;
            ListB = new List<B>();
        }
    
        public string nameA { get; set; }
        public List<B> B{ get; set; }
    }
    
    public class B
    {
    	
    	public int CForeignKey { get; set; }
    	
        [ForeignKey("CForeignKey")]
        public C C { get; set; }
    	
        public string nameB { get; set; }
    	
    	[Required]
    	public int AForeignKey { get; set; }
    	
    	[ForeignKey("AForeignKey")]
    	public A A {get; set;}
    	
    }
    
    public class C
    {
        public string nameC { get; set; }
    }
