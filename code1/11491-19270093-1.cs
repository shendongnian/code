    Dictionary<string, Assembly> loaded = new Dictionary<string,Assembly>();
    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
	{	Assembly resAssembly;
		string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll","");
		dllName = dllName.Replace(".", "_");
		if ( !loaded.ContainsKey( dllName ) )
		{	if (dllName.EndsWith("_resources")) return null;
			System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
			byte[] bytes = (byte[])rm.GetObject(dllName);
			resAssembly = System.Reflection.Assembly.Load(bytes);
			loaded.Add(dllName, resAssembly);
		}
		else
		{	resAssembly = loaded[dllName];  }
		return resAssembly;
	};	
