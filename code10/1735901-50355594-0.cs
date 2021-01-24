    public class ValidateAddressAttribute : Attribute, IModelValidator
    {
        public bool IsRequired => true;
        public string ErrorMessage { get; set; } = "Address is not valid";
       
        public IEnumerable<ModelValidationResult>Validate(ModelValidationContext context) 
        {
           List<ModelValidationResult> validationResults = new List<ModelValidationResult>();
           string address = context.Model as string;
           if(!IsAddressValid(address))
           {
             validationResults.Add(new ModelValidationResult("", ErrorMessage));            
           }
           return validationResults;
   
        }
      
        private bool IsAddressValid(string address)
        {
           bool isAddressValid;
           //set isAddressValid to true or false based on your validation logic
           return isAddressValid;
        }
    }
