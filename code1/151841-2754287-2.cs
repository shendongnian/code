		[ContractVerification(false)]
		public static void Init(string configurationPath, string[] mappingAssemblies)
		{
			Init(configurationPath, mappingAssemblies, null);
		}
		public static void Init(string configurationPath, string[] mappingAssemblies, string optionalArgument)
		{
			Contract.Requires<ArgumentNullException>(mappingAssemblies != null, "mapping assemblies");
			Contract.Requires<ArgumentNullException>(configurationPath != null, "configurationpath");
			Contract.Requires<ArgumentException>(configurationPath.Length > 0, "configurationPath is an empty string");
			Contract.Requires<FileNotFoundException>(File.Exists(configurationPath));
			Contract.Requires<FileNotFoundException>(Contract.ForAll<string>(mappingAssemblies, (n) => File.Exists(n)));
			// ... 
		}
