	private void LoadReferencedAssembly(Assembly assembly)
	{
		foreach (AssemblyName name in assembly.GetReferencedAssemblies())
		{
			if (!AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName == name.FullName))
			{
				this.LoadReferencedAssembly(Assembly.Load(name));
			}
		}
	}
