public class FunctionsAssemblyResolver
{
	static FunctionsAssemblyResolver()
	{
		AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
	}
	// At least one static member needs to be invoked in order to execute the static constructor,
	// but it will only run the constructor once.
	public static void StaticInstance() { }
	private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
	{
		var requestedAssembly = new AssemblyName(args.Name);
		try
		{
			// Feel free to resolve any other assemblies, but this will take care of Annotations
			return requestedAssembly.Name == "System.ComponentModel.Annotations"
				? Assembly.Load(requestedAssembly.Name)
				: null;
		}
		catch
		{
			// do nothing
		}
		return null;
	}
}
To use, just call `FunctionsAssemblyResolver.StaticInstance()` prior to any IoC resolves.  This can also be used for any non-IoC approach as well.
