    public static class WorkbenchService
    {    
        private static SynchronizationContext uiContext;
	static WorkbenchService()
	{
	    uiContext = WindowsFormsSynchronizationContext.Current;
	}
	
	/// <summary>
        /// Makes a call GUI threadSafe. WARNING: This method waits for the result of the operation, which can result in a dead-lock when the main thread waits for this thread to exit!
		/// </summary>
		public static void SafeThreadCall(SendOrPostCallback d, object state)
		{
			uiContext.Send(d, state);
		}
		/// <summary>
		/// Makes a call GUI thread safe without waiting for the returned value.
		/// </summary>
		public static void SafeThreadAsyncCall(SendOrPostCallback d, object state)
		{
			uiContext.Post(d, state);
		}
	}
