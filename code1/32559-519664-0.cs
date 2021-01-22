	Scan(x =>
	{
		x.TheCallingAssembly();
            x.IncludeNamespaceContainingType<FakeRepositories.FakeClientRepository>();
		x.With<FakeRepositoryScanner>(); 
	});
	private class FakeRepositoryScanner : ITypeScanner
	{
		public void Process(Type type, PluginGraph graph)
		{
			Type interfaceType = type.FindInterfaceThatCloses(typeof(IRepository<>));
			if (interfaceType != null)
			{
				graph.AddType(interfaceType, type);
			}
		}
	} 
