        private void timer1_Tick(object sender, EventArgs e)
		{
			var processes = Process.GetProcessesByName("Anticheat");
			foreach (var p in processes)
			{
				var task = Task.Factory.StartNew(() => p.Responding);
				const int maxWaitForResponse = 1000; //ms
				var processResponding = task.Wait(maxWaitForResponse) && task.Result;
				MessageBox.Show(processResponding ? "Yes" : "No");
			}
		}
