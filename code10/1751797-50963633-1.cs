    public class Doc
    {
    	public int DocId { get; set; }
    	public string DocName { get; set; }
    	public string Street { get; set; }
    	public int Number { get; set; }
    	public string Zip { get; set; }
    	public string Place { get; set; }
    
    	public virtual DocContract DocContract { get; set; }
    }
    
    public class DocContract
    {
    	[Key]
        [ForeignKey("Doc")]
    	public int DocId { get; set; }
    	public string Date { get; set; }
    	public virtual Doc Doc { get; set; }
    }
