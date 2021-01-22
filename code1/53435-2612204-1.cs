		...
		string p1 = "Yada yada.";
		long p2 = 4715821396025;
		int p3 = 4096;
		object args = new object[3] { p1, p2, p3 };
		Thread b1 = new Thread(new ParameterizedThreadStart(worker));
		b1.Start(args);
		...
		private void worker(object args)
		{
		  Array argArray = new object[3];
		  argArray = (Array)args;
		  string p1 = (string)argArray.GetValue(0);
		  long p2 = (long)argArray.GetValue(1);
		  int p3 = (int)argArray.GetValue(2);
		  ...
		}>
