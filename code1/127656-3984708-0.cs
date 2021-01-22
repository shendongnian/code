	public static class IOHelper
	{
		public static void DeleteDirectory(DirectoryInfo directoryInfo)
		{
			var emptyTempDirectory = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "IOHelperEmptyDirectory"));
			emptyTempDirectory.Create();
			var arguments = string.Format("\"{0}\" \"{1}\" /MIR", emptyTempDirectory.FullName, directoryInfo.FullName);
			using (var process = Process.Start(new ProcessStartInfo("robocopy")
												{
													Arguments = arguments,
													CreateNoWindow = true,
													UseShellExecute = false,
												}))
			{
				process.WaitForExit();
			}
			directoryInfo.Delete();
		}
	}
