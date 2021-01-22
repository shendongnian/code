    public static bool IsCastableTo(this Type from, Type to)
    {
    	// from https://web.archive.org/web/20141017005721/http://www.codeducky.org/10-utilities-c-developers-should-know-part-one/ 
    	Throw.IfNull(from, "from");
    	Throw.IfNull(to, "to");
    
    	// explicit conversion always works if to : from OR if 
    	// there's an implicit conversion
    	if (from.IsAssignableFrom(to) || from.IsImplicitlyCastableTo(to))
    	{
    		return true;
    	}
    
    	// for nullable types, we can simply strip off the nullability and evaluate the underyling types
    	var underlyingFrom = Nullable.GetUnderlyingType(from);
    	var underlyingTo = Nullable.GetUnderlyingType(to);
    	if (underlyingFrom != null || underlyingTo != null)
    	{
    		return (underlyingFrom ?? from).IsCastableTo(underlyingTo ?? to);
    	}
    
    	if (from.IsValueType)
    	{
    		try
    		{
    			ReflectionHelpers.GetMethod(() => AttemptExplicitCast<object, object>())
    				.GetGenericMethodDefinition()
    				.MakeGenericMethod(from, to)
    				.Invoke(null, new object[0]);
    			return true;
    		}
    		catch (TargetInvocationException ex)
    		{
    			return !(
    				ex.InnerException is RuntimeBinderException
    				// if the code runs in an environment where this message is localized, we could attempt a known failure first and base the regex on it's message
    				&& Regex.IsMatch(ex.InnerException.Message, @"^Cannot convert type '.*' to '.*'$")
    			);
    		}
    	}
    	else
    	{
    		// if the from type is null, the dynamic logic above won't be of any help because 
    		// either both types are nullable and thus a runtime cast of null => null will 
    		// succeed OR we get a runtime failure related to the inability to cast null to 
    		// the desired type, which may or may not indicate an actual issue. thus, we do 
    		// the work manually
    		return from.IsNonValueTypeExplicitlyCastableTo(to);
    	}
    }
    
    private static bool IsNonValueTypeExplicitlyCastableTo(this Type from, Type to)
    {
    	if ((to.IsInterface && !from.IsSealed)
    		|| (from.IsInterface && !to.IsSealed))
    	{
    		// any non-sealed type can be cast to any interface since the runtime type MIGHT implement
    		// that interface. The reverse is also true; we can cast to any non-sealed type from any interface
    		// since the runtime type that implements the interface might be a derived type of to.
    		return true;
    	}
    
    	// arrays are complex because of array covariance 
    	// (see http://msmvps.com/blogs/jon_skeet/archive/2013/06/22/array-covariance-not-just-ugly-but-slow-too.aspx).
    	// Thus, we have to allow for things like var x = (IEnumerable<string>)new object[0];
    	// and var x = (object[])default(IEnumerable<string>);
    	var arrayType = from.IsArray && !from.GetElementType().IsValueType ? from
    		: to.IsArray && !to.GetElementType().IsValueType ? to
    		: null;
    	if (arrayType != null)
    	{
    		var genericInterfaceType = from.IsInterface && from.IsGenericType ? from
    			: to.IsInterface && to.IsGenericType ? to
    			: null;
    		if (genericInterfaceType != null)
    		{
    			return arrayType.GetInterfaces()
    				.Any(i => i.IsGenericType
    					&& i.GetGenericTypeDefinition() == genericInterfaceType.GetGenericTypeDefinition()
    					&& i.GetGenericArguments().Zip(to.GetGenericArguments(), (ia, ta) => ta.IsAssignableFrom(ia) || ia.IsAssignableFrom(ta)).All(b => b));
    		}
    	}
    
    	// look for conversion operators. Even though we already checked for implicit conversions, we have to look
    	// for operators of both types because, for example, if a class defines an implicit conversion to int then it can be explicitly
    	// cast to uint
    	const BindingFlags conversionFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
    	var conversionMethods = from.GetMethods(conversionFlags)
    		.Concat(to.GetMethods(conversionFlags))
    		.Where(m => (m.Name == "op_Explicit" || m.Name == "op_Implicit")
    			&& m.Attributes.HasFlag(MethodAttributes.SpecialName)
    			&& m.GetParameters().Length == 1 
    			&& (
    				// the from argument of the conversion function can be an indirect match to from in
    				// either direction. For example, if we have A : B and Foo defines a conversion from B => Foo,
    				// then C# allows A to be cast to Foo
    				m.GetParameters()[0].ParameterType.IsAssignableFrom(from)
    				|| from.IsAssignableFrom(m.GetParameters()[0].ParameterType)
    			)
    		);
    
    	if (to.IsPrimitive && typeof(IConvertible).IsAssignableFrom(to))
    	{
    		// as mentioned above, primitive convertible types (i. e. not IntPtr) get special 
    		// treatment in the sense that if you can convert from Foo => int, you can convert
    		// from Foo => double as well
    		return conversionMethods.Any(m => m.ReturnType.IsCastableTo(to));
    	}
    
    	return conversionMethods.Any(m => m.ReturnType == to);
    }
    
    private static void AttemptExplicitCast<TFrom, TTo>()
    {
    	// based on the IL generated from
    	// var x = (TTo)(dynamic)default(TFrom);
    
    	var binder = Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(TTo), typeof(TypeHelpers));
    	var callSite = CallSite<Func<CallSite, TFrom, TTo>>.Create(binder);
    	callSite.Target(callSite, default(TFrom));
    }
