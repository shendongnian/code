const int SWP_NOSIZE = 1;
[StructLayout(LayoutKind.Sequential)]
public struct WINDOWPOS
{
	public IntPtr hwnd;
	public IntPtr hwndInsertAfter;
	public int x;
	public int y;
	public int cx;
	public int cy;
	public int flags;
}
protected override void WndProc(ref Message m)
{
	switch (m.Msg)
	{
		case 0x46: // WM_WINDOWPOSCHANGING
			this.HandleWindowPosChanging(ref m);
			base.WndProc(ref m);
			break;
		default:
			base.WndProc(ref m);
			break;
	}
}
protected virtual void HandleWindowPosChanging(ref Message m)
{
	try
	{
		WINDOWPOS pos = new WINDOWPOS();
		pos = (WINDOWPOS)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, pos.GetType());
		if (m_EnableAutoColumnResize && this.Columns.Count > 0 && (pos.flags & SWP_NOSIZE) == 0)
		{
			this.ResizeFreeSpaceFillingColumns(pos.cx - (this.Bounds.Width - this.ClientSize.Width));
		}
	}
	catch (ArgumentException) { }
}
private void ResizeFreeSpaceFillingColumns(int listViewWitdh)
{
	int lastColumn = this.Columns.Count - 1;
	int sumWidth = 0;
	for (int i = 0; i &lt; lastColumn; i++)
	{
		sumWidth += this.Columns[i].Width;
	}
	this.Columns[lastColumn].Width = listViewWitdh - sumWidth;
}
