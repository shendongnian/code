	public sealed class MsBuildRunner
	{
		public bool Run(FileInfo msbuildFile, string[] targets = null, IDictionary<string, string> properties = null, LoggerVerbosity loggerVerbosity = LoggerVerbosity.Detailed)
		{
			if (!msbuildFile.Exists) throw new ArgumentException("msbuildFile does not exist");
			if (targets == null)
			{
				targets = new string[] {};
			}
			if (properties == null)
			{
				properties = new Dictionary<string, string>();
			}
			Console.Out.WriteLine("Running {0} targets: {1} properties: {2}, cwd: {3}",
			                      msbuildFile.FullName,
			                      string.Join(",", targets),
			                      string.Join(",", properties),
			                      Environment.CurrentDirectory);
			var project = new Project(msbuildFile.FullName, properties, "4.0");
			return project.Build(targets, new ILogger[] { new ConsoleLogger(loggerVerbosity) });
		}
	}
