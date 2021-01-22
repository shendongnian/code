		public static bool IsImplementerOfRawGeneric(this Type type, Type baseType)
		{
			return type.GetInterfaces().Any(interfaceType =>
			{
				var current = interfaceType.IsGenericType ? interfaceType.GetGenericTypeDefinition() : interfaceType;
				return current == baseType;
			});
		}
		public static bool IsSubTypeOfRawGeneric(this Type type, Type baseType)
		{
			return IsImplementerOfRawGeneric(type, baseType) || IsSubclassOfRawGeneric(type, baseType);
		}
