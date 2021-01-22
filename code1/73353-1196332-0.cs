	class MouseMessageFilter : IMessageFilter, IDisposable
	{
		public MouseMessageFilter()
		{
		}
		public void Dispose()
		{
			StopFiltering();
		}
		#region IMessageFilter Members
		public bool PreFilterMessage(ref Message m)
		{
             // Call the appropriate event
             return false;
		}
		#endregion
		#region Events
		public class CancelMouseEventArgs : MouseEventArgs
		{...}
		public delegate void CancelMouseEventHandler(object source, CancelMouseEventArgs e);
		public event CancelMouseEventHandler MouseMove;
		public event CancelMouseEventHandler MouseDown;
		public event CancelMouseEventHandler MouseUp;
		public void StartFiltering()
		{
			StopFiltering();
			Application.AddMessageFilter(this);
		}
		public void StopFiltering()
		{
			Application.RemoveMessageFilter(this);
		}
	}
