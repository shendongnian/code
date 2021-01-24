    public class MyData
    {
     	[Name("Id")]
    	public int Id { get; set; }
        [Name("MaxDiscount")]
    	public int? MaxDiscount { get; set; }
    	[Name("Name")]
        public string Name { get; set; }
    	[Name("Active")]
    	[BooleanTrueValues("1")]
        [BooleanFalseValues("0")]
        public bool? Active { get; set; }
    	[Name("AltId")]
        public string AltId { get; set; }
    }
    
