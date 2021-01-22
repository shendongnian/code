    public class ReflectionUtility
    {
        internal static Func<object, object> GetGetter(PropertyInfo property)
        {
        	// get the get method for the property
        	MethodInfo method = property.GetGetMethod(true);
        
        	// get the generic get-method generator (ReflectionUtility.GetSetterHelper<TTarget, TValue>)
        	MethodInfo genericHelper = typeof(ReflectionUtility).GetMethod(
        		"GetGetterHelper",
        		BindingFlags.Static | BindingFlags.NonPublic);
        
        	// reflection call to the generic get-method generator to generate the type arguments
        	MethodInfo constructedHelper = genericHelper.MakeGenericMethod(
        		method.DeclaringType,
        		method.ReturnType);
        
        	// now call it. The null argument is because it's a static method.
        	object ret = constructedHelper.Invoke(null, new object[] { method });
        
        	// cast the result to the action delegate and return it
        	return (Func<object, object>) ret;
        }
        
        static Func<object, object> GetGetterHelper<TTarget, TResult>(MethodInfo method)
        	where TTarget : class // target must be a class as property sets on structs need a ref param
        {
        	// Convert the slow MethodInfo into a fast, strongly typed, open delegate
        	Func<TTarget, TResult> func = (Func<TTarget, TResult>) Delegate.CreateDelegate(typeof(Func<TTarget, TResult>), method);
        
        	// Now create a more weakly typed delegate which will call the strongly typed one
        	Func<object, object> ret = (object target) => (TResult) func((TTarget) target);
        	return ret;
        }
    }
