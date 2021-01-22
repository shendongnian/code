var inputLine = ReadLine(5);
    		public static string ReadLine(uint timeoutSeconds, Func<uint, string> countDownMessage, uint samplingFrequencyMilliseconds)
    		{
    			if (timeoutSeconds == 0)
    				return null;
    			var timeoutMilliseconds = timeoutSeconds * 1000;
    			if (samplingFrequencyMilliseconds > timeoutMilliseconds)
    				throw new ArgumentException("Sampling frequency must not be greater then timeout!", "samplingFrequencyMilliseconds");
    			CancellationTokenSource cts = new CancellationTokenSource();
    			Task.Factory
    				.StartNew(() => SpinUserDialog(timeoutMilliseconds, countDownMessage, samplingFrequencyMilliseconds, cts.Token), cts.Token)
    				.ContinueWith(t => {
    					var hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
    					PostMessage(hWnd, 0x100, 0x0D, 9);
    				}, TaskContinuationOptions.NotOnCanceled);
    			var inputLine = Console.ReadLine();
    			cts.Cancel();
    			return inputLine;
    		}
    		private static void SpinUserDialog(uint countDownMilliseconds, Func<uint, string> countDownMessage, uint samplingFrequencyMilliseconds,
    			CancellationToken token)
    		{
    			while (countDownMilliseconds > 0)
    			{
    				token.ThrowIfCancellationRequested();
    				Thread.Sleep((int)samplingFrequencyMilliseconds);
    				countDownMilliseconds -= countDownMilliseconds > samplingFrequencyMilliseconds
    					? samplingFrequencyMilliseconds
    					: countDownMilliseconds;
    			}
    		}
    		[DllImport("User32.Dll", EntryPoint = "PostMessageA")]
    		private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
