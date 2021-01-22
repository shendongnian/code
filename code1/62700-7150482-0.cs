	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace SSA.Utility
	{
		public class BackgroundTaskManager : IDisposable
		{
			private System.Windows.Threading.Dispatcher _OwnerDispatcher;
			private System.Windows.Threading.Dispatcher _WorkerDispatcher;
			private System.Threading.Thread _WorkerThread;
			private Boolean _WorkerBusy;
			private System.Threading.EventWaitHandle _WorkerStarted = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset);
			public BackgroundTaskManager()
			{
				_OwnerDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
				_WorkerThread = new System.Threading.Thread(new System.Threading.ThreadStart(WorkerStart));
				_WorkerThread.Name = "BackgroundTaskManager:" + DateTime.Now.Ticks.ToString();
				_WorkerThread.IsBackground = true;
				_WorkerThread.Start();
				_WorkerStarted.WaitOne();
			}
			public Boolean IsBusy
			{
				get { return _WorkerBusy; }
			}
			public System.Windows.Threading.Dispatcher Dispatcher 
			{
				get {
					return _WorkerDispatcher;
				}
			}
			public System.Windows.Threading.Dispatcher OwnerDispatcher
			{
				get
				{
					return _OwnerDispatcher;
				}
			}
			private void WorkerStart()
			{
				_WorkerDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
				_WorkerDispatcher.Hooks.DispatcherInactive += WorkDone;
				_WorkerDispatcher.Hooks.OperationPosted += WorkAdded;
				_WorkerStarted.Set();
				System.Windows.Threading.Dispatcher.Run();
			}
			private void WorkAdded(Object sender, System.Windows.Threading.DispatcherHookEventArgs e)
			{
				_WorkerBusy = true;
			}
			private void WorkDone(Object sender, EventArgs e)
			{
				_WorkerBusy = false;
			}
			public void Dispose()
			{
				if (_WorkerDispatcher != null)
				{
					_WorkerDispatcher.InvokeShutdown();
					_WorkerDispatcher = null;
				}
			}
		}
	}
	// Useage (not tested)
	private SSA.Utility.BackgroundTaskManager _background = new SSA.Utility.BackgroundTaskManager();
	public void LongTaskAsync() 
	{
	  _background.Dispatcher.BeginInvoke(new Action(LongTask), null);
	}
	public void LongTask() 
	{
	   System.Threading.Thread.Sleep(10000); // simulate a long task
	   _background.OwnerDispatcher.BeginInvoke(new Action<STATUSCLASS>(LongTaskUpdate), statusobject);
	}
	public void LongTaskUpdate(STATUSCLASS statusobject) {
	}
