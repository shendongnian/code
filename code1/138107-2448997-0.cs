    public interface IParamValidator<TParams> 
        where TParams : IActionParameters
    {
        bool ValidateParameters( TParams parameters );
    }
    
    public abstract class BaseBusinessAction<TActionParameters,TParamValidator> 
        where TActionParameters : IActionParameters
        where TParamValidator : IParamValidator<TActionParameters>, new()
    {
        protected BaseBusinessAction(TActionParameters actionParameters)
        {
            if (actionParameters == null) 
                throw new ArgumentNullException("actionParameters"); 
    
            // delegate detailed validation to the supplied IParamValidator
            var paramValidator = new TParamValidator();
            // you may want to implement the throw inside the Validator 
            // so additional detail can be added...
            if( !paramValidator.ValidateParameters( actionParameters ) )
                throw new ArgumentException("Valid parameters must be supplied", "actionParameters");
    
            this.Parameters = actionParameters;
        }
     }
    
    public class MyAction : BaseBusinessAction<MyActionParams,MyActionValidator>
    {
        // nested validator class
        private class MyActionValidator : IParamValidator<MyActionParams>
        {
            public MyActionValidator() {} // default constructor 
            // implement appropriate validation logic
            public bool ValidateParameters( MyActionParams params ) { return true; /*...*/ }
        }
    }
    
