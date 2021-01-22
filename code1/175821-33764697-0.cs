    public DynamicObjectContextObjectClass
    {
      ObjectContext internalObjectContext;
    
    }
    public class ServiceUserNamePasswordValidator : UserNamePasswordValidator
    {
        
        public DynamicObjectContextObjectClass dynamiccontext;
    
    
        public override void Validate(string userName, string password)
        {
    	    if(dynamiccontext.internalObjectContext.isdisposed)
    	    {
    
    		dynamiccontext.internalObjectContext = new Context;
    
                }
                try
                {
                    if (string.IsNullOrEmpty(userName) || password == null)
                    {
                        //throw new ArgumentNullException();
                        throw new FaultException("Username cannot be null or empty; Password cannot be null and should not be empty");
                    }
    	   }
       }
    } 
