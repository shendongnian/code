	public class FormContainingListView : Form, IMessageFilter
	{
		public FormContainingListView()
		{
			// ...
			Application.AddMessageFilter(this);
		}
		
		#region mouse wheel without focus
		// P/Invoke declarations
		[DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point pt);
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == 0x20a)
			{
				// WM_MOUSEWHEEL, find the control at screen position m.LParam
				Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
				IntPtr hWnd = WindowFromPoint(pos);
				if (hWnd != IntPtr.Zero && hWnd != m.HWnd && System.Windows.Forms.Control.FromHandle(hWnd) != null)
				{
					SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
					return true;
				}
			}
			return false;
		}
		#endregion
	}
