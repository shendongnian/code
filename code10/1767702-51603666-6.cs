    public class Factory : IFactory
	{
		protected readonly IDependency1 _dependency1; //Injected
		protected readonly IDependency2 _dependency2; //Injected
	
		public Factory(IDependency1 dependency1, IDependency2 dependency2)
		{
			_dependency1 = dependency1;
			_dependency2 = dependency2;
		}
		
		public BaseClass Resolve(string libraryName, string typeName)
		{
			var assembly = Assembly.LoadFile(libraryName);
			var type = assembly.GetType(typeName);
			var args = new object [] { _dependency1, _dependency2 };
			return (BaseClass)Activator.CreateInstance(type, args);
		}
	}
