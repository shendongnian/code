	// This is a better way to pass in what tab stops I want...
	SetTabStops(textBox, new int[] { 12,120 });
	// And the code for the SetTabsStops method itself...
	private const uint EM_SETTABSTOPS = 0x00CB;
		
	[DllImport("User32.dll")]
	private static extern uint SendMessage(IntPtr hWnd, uint wMsg, int wParam, int[] lParam);
	public static void SetTabStops(TextBox textBox, int[] tabs)
	{
		SendMessage(textBox.Handle, EM_SETTABSTOPS, tabs.Length, tabs);
	}
