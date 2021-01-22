	using System;
	using System.Windows.Forms;
	public class HourGlass : IDisposable
	{
		public static bool ApplicationEnabled
		{
			get{ return Application.UseWaitCursor; }
			set
			{
				Form activeFrom = Form.ActiveForm;
				if (activeFrom == null || ApplicationEnabled == value) return;
				if (ApplicationEnabled == value)return;
				Application.UseWaitCursor = (bool)value;
				if (activeFrom.InvokeRequired)
				{
					activeFrom.BeginInvoke(new Action(() =>
					{
						if (activeFrom.Handle != IntPtr.Zero)
						SendMessage(activeFrom.Handle, 0x20, activeFrom.Handle, (IntPtr)1); // Send WM_SETCURSOR
					}));
				}
				else
				{
					if (activeFrom.Handle != IntPtr.Zero)
					SendMessage(activeFrom.Handle, 0x20, activeFrom.Handle, (IntPtr)1); // Send WM_SETCURSOR
				}
			}
		}
		private Form f;
		public HourGlass() 
		{
			this.f = Form.ActiveForm;
			if (f == null)
			{
				throw new ArgumentException();
			}
			Enabled = true;
		}
		public HourGlass(bool enabled)
		{
			this.f = Form.ActiveForm;
			if (f == null)
			{
				throw new ArgumentException();
			}
			Enabled = enabled;
		}
		public HourGlass(Form f, bool enabled)
		{
			this.f = f;
			if (f == null)
			{
				throw new ArgumentException();
			}
			Enabled = enabled;
		}
		public HourGlass(Form f)
		{
			this.f = f;
			if (f == null)
			{
				throw new ArgumentException();
			}
			Enabled = true;
		}
		public void Dispose()
		{
			Enabled = false;
		}
		public bool Enabled
		{
			get { return f.UseWaitCursor; }
			set
			{
				if (f == null || Enabled == value) return;
				if (Application.UseWaitCursor == true && value == false) return;
				f.UseWaitCursor = (bool)value;
				if(f.InvokeRequired)
				{
					f.BeginInvoke(new Action(()=>
					{
						if (f.Handle != IntPtr.Zero)
						SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1); // Send WM_SETCURSOR
					}));
				}
				else
				{
					if (f.Handle != IntPtr.Zero)
					SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1); // Send WM_SETCURSOR
				}
			}
		}
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
	}
