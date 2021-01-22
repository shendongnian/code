		public static async Task WaitForExitAsync(this Process process, CancellationToken cancellationToken)
		{
			while (!process.HasExited)
			{
				await Task.Delay(100, cancellationToken);
			}
		}
