    public static object InvokeGenericMethodWithRuntimeGenericArguments(Action methodDelegate, Type[] runtimeGenericArguments, params object[] parameters)
    		{
    			if (parameters == null)
    			{
    				parameters = new object[0];
    			}
    			if (runtimeGenericArguments == null)
    			{
    				runtimeGenericArguments = new Type[0];
    			}
    
    			var myMethod = methodDelegate.Target.GetType()
    						 .GetMethods()
    						 .Where(m => m.Name == methodDelegate.Method.Name)
    						 .Select(m => new
    						 {
    							 Method = m,
    							 Params = m.GetParameters(),
    							 Args = m.GetGenericArguments()
    						 })
    						 .Where(x => x.Params.Length == parameters.Length
    									 && x.Args.Length == runtimeGenericArguments.Length
    						 )
    						 .Select(x => x.Method)
    						 .First().MakeGenericMethod(runtimeGenericArguments);
    			return myMethod.Invoke(methodDelegate.Target, parameters);
    		}
