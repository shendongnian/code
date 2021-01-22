		public static bool IsAssignableToGenericType(Type givenType, Type genericType)
		{
			var interfaces = givenType.GetInterfaces().Where(it => it.IsGenericType).Select(it => it.GetGenericTypeDefinition());
			var foundInterface = interfaces.FirstOrDefault(it => it == genericType);
			if (foundInterface != null) return true;
			Type baseType = givenType.BaseType;
			if (baseType == null) return false;
			return baseType.IsGenericType ?
				baseType.GetGenericTypeDefinition() == genericType :
				IsAssignableToGenericType(baseType, genericType);
		}
