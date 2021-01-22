    public static string ShellExecute(this string path, string command, TextWriter writer, params string[] arguments)
		{
			using (var process = Process.Start(new ProcessStartInfo { WorkingDirectory = path, FileName = command, Arguments = string.Join(" ", arguments), UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true }))
			{
				using (process.StandardOutput)
				{
					writer.WriteLine(process.StandardOutput.ReadToEnd());
				}
				using (process.StandardError)
				{
					writer.WriteLine(process.StandardError.ReadToEnd());
				}
			}
			return path;
		}
