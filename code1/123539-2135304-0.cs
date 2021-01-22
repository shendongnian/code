    	public class GenericConnectionScannerWithScope : IRegistrationConvention
	{
		private readonly Type _openType;
		private readonly InstanceScope _instanceScope;
		public GenericConnectionScannerWithScope(Type openType, InstanceScope instanceScope)
		{
			_openType = openType;
			_instanceScope = instanceScope;
			if (!_openType.IsOpenGeneric())
			{
				throw new ApplicationException("This scanning convention can only be used with open generic types");
			}
		}
		public void Process(Type type, Registry registry)
		{
			Type interfaceType = type.FindInterfaceThatCloses(_openType);
			if (interfaceType != null)
			{
				registry.For(interfaceType).LifecycleIs(_instanceScope).Add(type);
			}
		}
	}
	public static class StructureMapConfigurationExtensions
	{
		public static void ConnectImplementationsToSingletonTypesClosing(this IAssemblyScanner assemblyScanner, Type openGenericType)
		{
			assemblyScanner.With(new GenericConnectionScannerWithScope(openGenericType, InstanceScope.Singleton));
		}
	}
