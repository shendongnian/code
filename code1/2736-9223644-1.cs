        private void DisplayMemoryUsageInTitleAsync()
		{
			origWindowTitle = this.Title; // set WinForms or WPF Window Title to field
			BackgroundWorker wrkr = new BackgroundWorker();
			wrkr.WorkerReportsProgress = true;
			wrkr.DoWork += (object sender, DoWorkEventArgs e) => {
				Process currProcess = Process.GetCurrentProcess();
				PerformanceCounter perfCntr = new PerformanceCounter();
				perfCntr.CategoryName = "Process";
				perfCntr.CounterName = "Working Set - Private";
				perfCntr.InstanceName = currProcess.ProcessName;
				while (true)
				{
					int value = (int)perfCntr.NextValue() / 1024;
					string privateMemoryStr = value.ToString("n0") + "KB [Private Bytes]";
					wrkr.ReportProgress(0, privateMemoryStr);
					Thread.Sleep(1000);
				}
			};
			wrkr.ProgressChanged += (object sender, ProgressChangedEventArgs e) => {
				string val = e.UserState as string;
				if (!string.IsNullOrEmpty(val))
					this.Title = string.Format(@"{0}   ({1})", origWindowTitle, val);
			};
			wrkr.RunWorkerAsync();
		}`
