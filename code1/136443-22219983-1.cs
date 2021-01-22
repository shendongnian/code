    public class RequreIfValidator : DataAnnotationsModelValidator <RequiredIfAttribute>
    {
             
        ControllerContext ccontext;
        public RequreIfValidator(ModelMetadata metadata, ControllerContext context, RequiredIfAttribute attribute)
           : base(metadata, context, attribute)
        {
            ccontext = context;// I need only http request
        }
        
	//override it for custom client-side validation 
         public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
         {       
                   //here you can customize it as you want
             ModelClientValidationRule rule = new ModelClientValidationRule()
             {
                 ErrorMessage = ErrorMessage,
		//and here is what i need on client side - if you want to make field required on client side just make ValidationType "required"	
                 ValidationType =(ccontext.HttpContext.Request["extOperation"] == "2") ? "required" : "none";
             };
             return new ModelClientValidationRule[] { rule };
          }
    }
