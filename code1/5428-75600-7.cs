		public static bool IsDerivedFromGenericType(Type givenType, Type genericType)
		{
			Type baseType = givenType.BaseType;
			if (baseType == null) return false;
			if (baseType.IsGenericType)
			{
				if (baseType.GetGenericTypeDefinition() == genericType) return true;
			}
			return IsDerivedFromGenericType(baseType, genericType);
		}
