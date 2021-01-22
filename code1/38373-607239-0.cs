				foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) // this is making the assumption that all assemblies we need are already loaded.
				{
					foreach (Type type in assembly.GetTypes())
					{
						var attribs = type.GetCustomAttributes(typeof(MyCustomAttribute), false);
						if (attribs != null && attribs.Length > 0)
						{
							// add to a cache.
