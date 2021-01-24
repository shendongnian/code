    public class AddressController : ApiController
    {
      private readonly IJsonEntityValidator<HomeAddressSearch.Properties> _validator = null;
    
      public AddressController(IJsonEntityValidator validator)
      {
        _validator = validator;
      }
      public ActionResult Search(string jsonModel)
      { 
        if(string.IsNullOrEmpty(jsonModel))
          // handle response for missing model.
    
        var result = _validator.Validate<HomeAddressSearch.Properties>(jsonModel);
        if (!result.IsValid) 
          // handle validation failure for the model.
      }
    }
    
    public class JSonEntityValidator<T> : IJsonEntityValidator<T> where T: class
    {
      IJsonEntityValidator<T>.Validate(string jsonModel)
      {
        // Generate a JSON schema from your object.
        var schemaGenerator = new JSchemaGenerator();
        var schema = schemaGenerator.Generate(typeof(T)); 
        
        // Parse the JSON passed in, then validate it against the schema before proceeding.
        List<ValidationErrors> validationErrors;
        JObject model = JObject.Parse(jsonModel);
        bool isValid = model.IsValid(schema, out validationErrors);
        return new JsonValidateResult
        {
          IsValid = isValid,
          ValidationErrors = validationErrors
        };
      }
    }
