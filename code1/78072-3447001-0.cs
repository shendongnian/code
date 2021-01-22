			foreach (string dllPath in Directory.GetFiles(directoryPath, "*.dll"))
			{
				try
				{
					Assembly a = Assembly.ReflectionOnlyLoadFrom(dllPath);
					if (Matches(a.FullName) && !loadedAssemblyNames.Contains(a.FullName))
					{
						App.Load(a.FullName);
					}
				}
				catch (BadImageFormatException ex)
				{
					Trace.TraceError(ex.ToString());
				}
			}
