	public abstract class Constant<T, TConstant>
	{
		private Dictionary<Type, TConstant> _constants;
		
		protected Constant()
		{
			_constants = new Dictionary<Type, TConstant>();
			
			// Here any class deriving from Constant<T, TConstant>
			// should put a value in the dictionary for every type
			// deriving from T, using the DefineConstant method below.
			DefineConstants();
			
			EnsureConstantsDefinedForAllTypes();
		}
		
		protected abstract void DefineConstants();
		protected void DefineConstant<U>(TConstant constant) where U : T
		{
			_constants[typeof(U)] = constant;
		}
		
		private void EnsureConstantsDefinedForAllTypes()
		{
			Type baseType = typeof(T);
			
			// Here we discover all types deriving from T
			// and verify that each has a key present in the
			// dictionary.
			var appDomain = AppDomain.CurrentDomain;
			var assemblies = appDomain.GetAssemblies();
			var types = assemblies
				.SelectMany(a => a.GetTypes())
				.Where(t => baseType.IsAssignableFrom(t));
			
			foreach (Type t in types)
			{
				if (!_constants.ContainsKey(t))
				{
					throw new Exception(
						string.Format("No constant defined for type '{0}'.", t)
					);
				}
			}
		}
		
		public TConstant GetValue<U>() where U : T
		{
			return _constants[typeof(U)];
		}
	}
