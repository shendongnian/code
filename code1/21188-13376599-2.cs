    using System.Collections.Concurrent;
    
    namespace System
    {
	    public static class TypeExtension
	    {
            //a thread-safe way to hold default instances created at run-time
		    private static ConcurrentDictionary<Type, object> typeDefaults =
               new ConcurrentDictionary<Type, object>();
		    public static object GetDefaultValue(this Type type)
		    {
			    return type.IsValueType
                   ? typeDefaults.GetOrAdd(type, Activator.CreateInstance)
                   : null;
            }
        }
    }
