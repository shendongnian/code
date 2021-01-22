	using System.Reflection;
	public static class StructUtils
	{
		public static bool IsImmutable(Type type, int depth = 5)
		{
			if (type == typeof(string) || type.IsValueType)
			{
				return true;
			}
			else if (depth == 0)
			{
				return false;
			}
			else
			{
				return type.GetFields()
					.Where(fInfo => !fInfo.IsStatic) // Filter out statics
					.Where(fInfo => fInfo.FieldType != type) // Filter out 1st level recursion
					.All(fInfo => fInfo.IsInitOnly && IsImmutable(fInfo.FieldType, depth - 1)) &&
					type.GetProperties()
					   .Where(pInfo => !pInfo.GetMethod.IsStatic) // Filter out statics
					   .Where(pInfo => pInfo.PropertyType != type) // Filter out 1st level recursion
					   .All(pInfo => !SetIsAllowed(pInfo, checkNonPublicSetter: true) && IsImmutable(pInfo.PropertyType, depth - 1));
			}
		}
		private static bool SetIsAllowed(PropertyInfo pInfo, bool checkNonPublicSetter = false)
		{
			var setMethod = pInfo.GetSetMethod(nonPublic: checkNonPublicSetter);
			return pInfo.CanWrite &&
				   ((!checkNonPublicSetter && setMethod.IsPublic) ||
					(checkNonPublicSetter && (setMethod.IsPrivate || setMethod.IsFamily || setMethod.IsPublic || setMethod.IsAbstract)));
		}
	}
