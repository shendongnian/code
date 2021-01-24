    public class Person 
    {
    	[Key]
    	public int Id { get; set;}
    	public string Name {get; set;}
    	
       [ForeignKey("OfficeId")]
       public virtual Office  Office  {get;set;}
       public int? Office Id {get;set;} = null;
    }
