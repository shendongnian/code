    /// <summary>
	/// Windows Messages
	/// Defined in winuser.h from Windows SDK v6.1
	/// Documentation pulled from MSDN.
	/// For more look at: http://www.pinvoke.net/default.aspx/Enums/WindowsMessages.html
	/// </summary>
	public enum WM : uint
	{
		/// <summary>
		/// Notifies an application of a change to the hardware configuration of a device or the computer.
		/// </summary>
		DEVICECHANGE = 0x0219,
	}
	protected override void WndProc(ref Message m)
	{
		switch ((WM)m.Msg)
		{
			case WM.DEVICECHANGE:
				//ToDo: put your code here.
				break;
		}
		base.WndProc(ref m);
	}
