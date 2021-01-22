	using CSharpTest.Net.Processes;
		static void Update(string sourcePath, Action<string> output)
		{
			ProcessRunner run = new ProcessRunner("svn.exe", "update", "{0}");
			run.OutputReceived +=
				delegate(Object o, ProcessOutputEventArgs e) { output(e.Data); };
			int exitCode = run.RunFormatArgs(sourcePath);
			if (exitCode != 0)
				throw new ApplicationException(
					String.Format("SVN.exe returned {0}.", exitCode)
					);
		}
