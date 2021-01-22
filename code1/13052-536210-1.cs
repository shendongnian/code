    		private static void Main(string[] args)
		{
			try
			{
				// ...
			}
			catch (Exception exception)
			{
				System.Diagnostics.Trace.Write(exception);
				#if DEBUG
				System.Diagnostics.Trace.Write("Waiting 20 seconds for debuggers to attach to process.");
				System.Threading.Thread.Sleep(20000);
				System.Diagnostics.Trace.Write("Continue with process...");
				#endif
				throw;
			}
		}
