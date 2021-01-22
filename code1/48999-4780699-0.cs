	public static class AssemblyHandler {
		private static Dictionary<String, Assembly> Assemblies;
		public static Assembly GetAssembly(String Name) {
			if (Assemblies == null) {
				Assemblies = new Dictionary<string, Assembly>();
				var mainAsm = Assembly.GetEntryAssembly();
				if (mainAsm == null) {
					var trace = new StackTrace();
					foreach (var frame in trace.GetFrames()) {
						var assembly = frame.GetMethod().DeclaringType.Assembly;
						if (assembly.GlobalAssemblyCache) {
							break;
						}
						mainAsm = assembly;
					}
				}
				Assemblies.Add(mainAsm.FullName, mainAsm);
				ScanReferencedAssemblies(mainAsm);
			}
			if (!Assemblies.ContainsKey(Name)) {
				return null;
			}
			return Assemblies[Name];
		}
		private static void ScanReferencedAssemblies(Assembly Asm) {
			foreach (var refAsmName in Asm.GetReferencedAssemblies()) {
				Assembly a = Assembly.Load(refAsmName);
				if (a.GlobalAssemblyCache) {
					continue;
				}
				if (!Assemblies.ContainsKey(a.FullName)) {
					Assemblies.Add(a.FullName, a);
					ScanReferencedAssemblies(a);
				}
			}
		}
		public static Type GetType(string AssemblyName, string TypeName) {
			return GetAssembly(AssemblyName).GetType(TypeName);
		}
	}
