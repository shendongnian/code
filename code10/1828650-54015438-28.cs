    bool IsDataHandlerMethod(MethodInfo methodInfo)
	{
		var dataHandlerAttributes = return (DataHandlerAttribute[])item.GetCustomAttributes(typeof(DataHandlerAttribute), true);
		if (attributes == null || attributes.Length == 0)
		{
			return false;
		}
		if (methodInfo is ConstructorInfo)
		{
			return false;
		}
		if (methodInfo.DeclaringType != null)
		{
			return false;
		}
		if (methodInfo.ReturnTpye != typeof(void))
		{
			return false;
		}
		var parameters = methodInfo.GetParameters();
		if (parameters.Length != 1)
		{
			return false;
		}
		if (paramters[0].IsByRef || paramters[0].IsOut)
		{
			return false;
		}
		return true;
	}
