		public static Type FollowPropertyPath<T>(string path)
		{
			if (path == null) throw new ArgumentNullException("path");
			Type currentType = typeof(T);
			foreach (string propertyName in path.Split('.'))
			{
				int brackStart = propertyName.IndexOf("[");
				var property = currentType.GetProperty(brackStart > 0 ? propertyName.Substring(0, brackStart) : propertyName);
				if (property == null)
					return null;
				
				currentType = property.PropertyType;
				
				if (brackStart > 0)
				{
					foreach (Type iType in currentType.GetInterfaces())
					{
						if (iType.IsGenericType && iType.GetGenericTypeDefinition() == typeof (IDictionary<,>))
						{
							currentType = iType.GetGenericArguments()[1];
							break;
						}
						if (iType.IsGenericType && iType.GetGenericTypeDefinition() == typeof (ICollection<>))
						{
							currentType = iType.GetGenericArguments()[0];
							break;
						}
					}
				}
			}
			return currentType;
		}
