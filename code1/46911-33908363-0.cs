	public static T Cast<T>(object obj)
	{
		return (T)obj;
	}
   ...
    //Invoke parent object's json function
    MethodInfo castMethod = this.GetType().GetMethod("Cast").MakeGenericMethod(baseObj.GetType());
    object castedObject = castMethod.Invoke(null, new object[] { baseObj });
    MethodInfo jsonMethod = baseObj.GetType ().GetMethod ("ToJSON");
    return (string)jsonMethod.Invoke (castedObject,null);
