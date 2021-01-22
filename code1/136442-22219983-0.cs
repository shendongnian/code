    public class RequiredIfAttribute : RequiredAttribute
    {
       
        public RequiredIfAttribute(/*You can put here pararmeters if You need, as seen in other answers of this topic*/)
        {
          
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
         
	    //You can put your logic here 	
	
            return ValidationResult.Success;//I don't need its server-side so it always valid on server but you can do what you need
        }
     
    }
