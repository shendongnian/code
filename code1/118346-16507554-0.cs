 	public static class Extra_Objects_ExtensionMethods
	{
		public static T clone<T>(this T objectToClone)
		{
			try
			{
				if (objectToClone.isNull())
					"[object<T>.clone] provided object was null (type = {0})".error(typeof(T));
				else
					return (T)objectToClone.invoke("MemberwiseClone");
			}
			catch(Exception ex)
			{
				"[object<T>.clone]Faild to clone object {0} of type {1}".error(objectToClone.str(), typeof(T));
			}
			return default(T);
		}	
	}
