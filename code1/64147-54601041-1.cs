    		public (string pkName, string imName) TryReflectionOnlyLoadFrom_GetManagedType(string fileName)
		{
			string pkName;
			string imName;
			try
			{
				Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile: fileName);
				assembly.ManifestModule.GetPEKind(
					peKind: out PortableExecutableKinds peKind,
					machine: out ImageFileMachine imageFileMachine);
				// Any CPU builds are reported as 32bit.
				// 32bit builds will have more value for PortableExecutableKinds
				if (peKind == PortableExecutableKinds.ILOnly && imageFileMachine == ImageFileMachine.I386)
				{
					pkName = "AnyCPU";
					imName = "";
				}
				else
				{
					PortableExecutableKindsNames.TryGetValue(
						key: peKind,
						value: out pkName);
					if (string.IsNullOrEmpty(value: pkName))
					{
						pkName = "*** ERROR ***";
					}
					ImageFileMachineNames.TryGetValue(
						key: imageFileMachine,
						value: out imName);
					if (string.IsNullOrEmpty(value: pkName))
					{
						imName = "*** ERROR ***";
					}
				}
				return (pkName, imName);
			}
			catch (Exception ex)
			{
				return (ExceptionHelper(ex), "");
			}
		}
