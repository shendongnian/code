    static class TypeExtensions {
    	public static IEnumerable<string> GetGenericTypeParameterNames(this Type type) {
    		if (type.IsGenericTypeDefinition) {
    			return type.GetGenericArguments().Select(t => t.Name);
    		} else if (type.IsGenericType) {
    			return type.GetGenericTypeDefinition().GetGenericArguments().Select(t => t.Name);
    		} else {
    			return Enumerable.Empty<string>();
    		}
    	}
    }
