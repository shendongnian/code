	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public class InitializeOnLoadAttribute : Attribute
	{
		Type type;
		public InitializeOnLoadAttribute(Type type) { this.type = type; }
		public Type Type { get { return type; } }
	}
    // somewhere very early in main exe initialization
	AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(AssemblyInitializer);
	static void AssemblyInitializer(object sender, AssemblyLoadEventArgs args)
	{
		// force static constructors in types specified by InitializeOnLoad
		foreach (InitializeOnLoadAttribute attr in args.LoadedAssembly.GetCustomAttributes(typeof(InitializeOnLoadAttribute), false))
			System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(attr.Type.TypeHandle);
	}
