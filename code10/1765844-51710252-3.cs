    public class RegisterNewUserDestructuringPolicy : IDestructuringPolicy
    {
    	public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
    	{
    		var request = value as RegisterNewUserRequest;
    		if (request == null)
    		{
    			result = null;
    			return false;
    		}
    
    		var logEventProperties = new List<LogEventProperty>
    			{
    				new LogEventProperty(nameof(request.Claims), propertyValueFactory.CreatePropertyValue(request.Claims)),
    				new LogEventProperty(nameof(request.Email), propertyValueFactory.CreatePropertyValue(request.Email)),
    				new LogEventProperty(nameof(request.Password), propertyValueFactory.CreatePropertyValue("****")),
    				new LogEventProperty(nameof(request.Roles), propertyValueFactory.CreatePropertyValue(request.Roles)),
    				new LogEventProperty(nameof(request.UserName),
    					propertyValueFactory.CreatePropertyValue(request.UserName))
    			};
    
    		result = new StructureValue(logEventProperties);
    		return true;
    	}
    }
