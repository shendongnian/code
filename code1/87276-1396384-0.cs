			List<ManualResetEvent> items = new List<ManualResetEvent>();
			foreach (Type job in queue)
			{
				WorkflowInstance myInstance = new WorkflowInstance(job, parameters);
				
				ManualResetEvent syncEvent = new ManualResetEvent(false);
				items.Add(syncEvent);
				// Completed
				myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) 
				{ 
					syncEvent.Set(); 
				};
				// Unhandled Exception
				myInstance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
				{
					// Message
					Console.WriteLine(e.UnhandledException.ToString());
					return UnhandledExceptionAction.Terminate;
				};
				// Aborted
				myInstance.OnAborted = delegate(WorkflowAbortedEventArgs e)
				{
					// Message
					Console.WriteLine(e.Reason);
					syncEvent.Set();
				};
				// Run
				myInstance.Run();
			}
			// Wait
			WaitHandle.WaitAll(items.ToArray());
