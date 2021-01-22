    using System;
    using System.Reflection;
    
    static class Example
    {
    	public static Tuple<Boolean, T?> TryParse<T>(this String candidate)
    		where T : struct
    	{
    		T? value = null;
    		Boolean success = false;
    
    		var parser = ParsingBinder<T>.GetParser();
    
    		try 
    		{ 
    			value = parser(candidate);
    			success = true;
    		} 
    		catch (FormatException) { }
    		
    		return new Tuple<bool,T?>(success, value);
    	}
    }
    
    static class ParsingBinder<T>
    {
    	static Func<String, T> parser;
    
    	public static Func<String, T> GetParser()
    	{
    		if (parser == null)
    			parser = getParser();
    
    		return parser;
    	}
    
    	private static Func<String, T> getParser()
    	{
    		MethodInfo methodInfo = typeof(T).GetMethod("Parse", new [] { typeof(String) });
    
    		if (methodInfo == null)
    			throw new Exception("Unable to retrieve a \"Parse\" method for type.");
    
    		return (Func<String, T>)Delegate.CreateDelegate(typeof(Func<String, T>), methodInfo);
    	}
    }
