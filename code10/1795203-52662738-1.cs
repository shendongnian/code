    public static class ExtenstionArray
    {
    	public static string ToRequestContent<T>(this T model) {
    		var list = model.GetType().GetProperties()
    			   .Select(x => new
    			   {
    				   val = x.GetValue(model).ToString(),
    				   name = x.Name
    			   })
    			   .Select(z => string.Join("=", z.name, z.val));
    
    		return "&"+ string.Join("&", list);
    	}
    }
