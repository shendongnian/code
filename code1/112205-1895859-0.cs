	public static class TypeExtensions {
		public static Type GetTypeDefinition ( this Type type ) {
			return type.IsGenericType ? type.GetGenericTypeDefinition () : type;
		}
		public static IEnumerable<Type> GetImproperComposingTypes ( this Type type ) {
			yield return type.GetTypeDefinition ();
			if ( type.IsGenericType ) {
				foreach ( var argumentType in type.GetGenericArguments () ) {
					foreach ( var t in argumentType.GetImproperComposingTypes () ) yield return t;
				}
			}
		}
		private static Dictionary<Type , Type> GetInferenceMap ( ParameterInfo[] parameters , Type[] types ) {
			var genericArgumentsMap = new Dictionary<Type , Type> ();
			var match = parameters.All ( parameter => parameter.ParameterType.GetImproperComposingTypes ().Zip ( types[parameter.Position].GetImproperComposingTypes () ).All ( a => {
				if ( !a.Item1.IsGenericParameter ) return a.Item1 == a.Item2;
				if ( genericArgumentsMap.ContainsKey ( a.Item1 ) ) return genericArgumentsMap[a.Item1] == a.Item2;
				genericArgumentsMap[a.Item1] = a.Item2;
				return true;
			} ) );
			return match ? genericArgumentsMap : null;
		}
		public static MethodInfo MakeGenericMethod ( this Type type , string name , Type[] types ) {
			var methods = from method in type.GetMethods ()
						  where method.Name == name
						  let parameters = method.GetParameters ()
						  where parameters.Length == types.Length
						  let genericArgumentsMap = GetInferenceMap ( parameters , types )
						  where genericArgumentsMap != null
						  select new {
							  method ,
							  genericArgumentsMap
						  };
			return methods.Select ( m => m.method.IsGenericMethodDefinition ? m.method.MakeGenericMethod ( m.method.GetGenericArguments ().Map ( m.genericArgumentsMap ).ToArray () ) : m.method ).SingleOrDefault ();
		}
	}
