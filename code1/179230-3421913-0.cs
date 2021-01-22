    public static string InstallUtilPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
	private bool callInstallUtil(string[] installUtilArguments)
	{
		Process proc = new Process();
		proc.StartInfo.FileName = Path.Combine(InstallUtilPath, "installutil.exe");
		proc.StartInfo.Arguments = String.Join(" ", installUtilArguments);
		proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.UseShellExecute = false;
		proc.Start();
		string outputResult = proc.StandardOutput.ReadToEnd();
		proc.WaitForExit();
		//  ---check result---
		if (proc.ExitCode != 0)
		{
			Errors.Add(String.Format("InstallUtil error -- code {0}", proc.ExitCode));
			return false;
		}
		return true;
	} 
