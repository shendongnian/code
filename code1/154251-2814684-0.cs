    public class Book
    {
    	public PrimaryContact PrimaryContact { get; set; }
    	public SecondaryContact SecondaryContact { get; set; }
    
    	[Required(ErrorMessage = "Book name is required")]
    	public string Name { get; set; }
    }
    
    public class Contact
    {
    	[Required(ErrorMessage = "Name is required")]
    	public string Name { get; set; }
    }
    
    [MetadataType(typeof(PrimaryContactMD))]
    public class PrimaryContact : Contact
    {
    	class PrimaryContactMD
    	{
    		[Required(ErrorMessage = "Primary Contact Name is required")]
    		public string Name { get; set; }
    	}
    }
    
    [MetadataType(typeof(SecondaryContactMD))]
    public class SecondaryContact : Contact
    {
    	class SecondaryContactMD
    	{
    		[Required(ErrorMessage = "Secondary Contact Name is required")]
    		public string Name { get; set; }
    	}
    }
