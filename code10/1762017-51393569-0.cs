	public CustomObject<T> MethodA<T>(T arg1) where T : class
	{
	    if (arg1 is IInterface)
		{
			var method = this.GetType().GetMethod("MethodB").MakeGenericMethod(arg1.GetType());
			return (CustomObject<T>)method.Invoke(this, new [] { arg1 });
		}
		return null;
	}
