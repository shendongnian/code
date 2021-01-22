AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender2, ResolveEventArgs e2)
			{
				var requestedNameAssembly = new AssemblyName(e2.Name);
				var requestedName = requestedNameAssembly.Name;
				if (requestedName.EndsWith(".resources")) return null;
				var binFolder = System.Web.Hosting.HostingEnvironment.MapPath("~/bin");
				var fullPath = Path.Combine(binFolder, requestedName) + ".dll";
				if (File.Exists(fullPath))
				{
					return Assembly.LoadFrom(fullPath);
				}
				return null;
			};
