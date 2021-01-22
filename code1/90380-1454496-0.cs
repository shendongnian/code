	public class HookResolver
	{
		Dictionary<string, Assembly> _loaded;
		public HookResolver()
		{
			_loaded = new Dictionary<string, Assembly>(StringComparer.OrdinalIgnoreCase);
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
		}
		System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			string name = args.Name.Split(',')[0];
			Assembly asm;
			lock (_loaded)
			{
				if (!_loaded.TryGetValue(name, out asm))
				{
					using (Stream io = this.GetType().Assembly.GetManifestResourceStream(name))
					{
						byte[] bytes = new BinaryReader(io).ReadBytes((int)io.Length);
						asm = Assembly.Load(bytes);
						_loaded.Add(name, asm);
					}
				}
			}
			return asm;
		}
	}
