    		private static (string pkName, string imName) FindPEKind(string filename)
		{
			// some files, especially if loaded into memory
			// can cause errors. Thus, load into their own appdomain
			AppDomain tempDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
			PEWorkerClass remoteWorker =
				(PEWorkerClass)tempDomain.CreateInstanceAndUnwrap(
					typeof(PEWorkerClass).Assembly.FullName,
					typeof(PEWorkerClass).FullName);
			(string pkName, string imName) = remoteWorker.TryReflectionOnlyLoadFrom_GetManagedType(filename);
			AppDomain.Unload(tempDomain);
			return (pkName, imName);
		}
