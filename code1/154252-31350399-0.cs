    using System.ComponentModel.DataAnnotations;
    
    public class Book {
    	[CustomValidation(typeof(Book), "ValidateContact")]
    	public Contact PrimaryContact { get; set; }
    
    	[CustomValidation(typeof(Book), "ValidateContact")]
    	public Contact SecondaryContact { get; set; }
    
    	[Required(ErrorMessage = "Book name is required")]
    	public string Name { get; set; }
    
    	public static ValidationResult ValidateContact(Contact contact, ValidationContext context) {
    		ValidationResult result = null;
    
    		if (contact == null) {
    			result = new ValidationResult(string.Format("{0} is required.", context.DisplayName));
    		}
    
    		return result;
    	}
    }
    
    public class Contact {
    	[Required(ErrorMessage = "Name is required")]
    	public string Name { get; set; }
    }
