			var p = new Process()
			{
				StartInfo = new ProcessStartInfo("netstat")
				{
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
				}
			};
			
			var outputWriter = new StringWriter();
			p.OutputDataReceived += (sender, args) => outputWriter.WriteLine(args.Data);
			var errorWriter = new StringWriter();
			p.ErrorDataReceived += (sender, args) => errorWriter.WriteLine(args.Data);
			p.Start();
			p.BeginOutputReadLine();
			p.BeginErrorReadLine();		
			p.WaitForExit();
			if (p.ExitCode == 0)
			{
				Console.WriteLine(outputWriter.GetStringBuilder().ToString());
			}
			else
			{
				Console.WriteLine("Process failed with error code {0}\nMessage Was:\n{1}", p.ExitCode
					, errorWriter.GetStringBuilder().ToString());
			}
