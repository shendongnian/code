	Process p = new Process()
	{
	  StartInfo = new ProcessStartInfo()
	  {
	    FileName = exe,
	    Arguments = args,
	    UseShellExecute = false,
	    RedirectStandardOutput = true,
	    RedirectStandardError = true
	  }
	};
	p.Start();
	string cv_error = null;
	Thread et = new Thread(() => { cv_error = p.StandardError.ReadToEnd(); });
	et.Start();
	string cv_out = null;
	Thread ot = new Thread(() => { cv_out = p.StandardOutput.ReadToEnd(); });
	ot.Start();
	p.WaitForExit();
	ot.Join();
	et.Join();
