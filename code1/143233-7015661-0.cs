    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class Form1
    {
	public Form1()
	{
		// This call is required by the Windows Form Designer.
		InitializeComponent();
		// Add any initialization after the InitializeComponent() call.
		this.NativeTabControl1 = new NativeTabControl();
		this.NativeTabControl2 = new NativeTabControl();
		this.NativeTabControl1.AssignHandle(this.TabControl1.Handle);
		this.NativeTabControl2.AssignHandle(this.TabControl2.Handle);
	}
	private NativeTabControl NativeTabControl1;
	private NativeTabControl NativeTabControl2;
	private class NativeTabControl : NativeWindow
	{
		protected override void WndProc(ref Message m)
		{
			if ((m.Msg == TCM_ADJUSTRECT)) {
				RECT rc = (RECT)m.GetLParam(typeof(RECT));
				//Adjust these values to suit, dependant upon Appearance
				rc.Left -= 3;
				rc.Right += 3;
				rc.Top -= 3;
				rc.Bottom += 3;
				Marshal.StructureToPtr(rc, m.LParam, true);
			}
			base.WndProc(ref m);
		}
		private const Int32 TCM_FIRST = 0x1300;
		private const Int32 TCM_ADJUSTRECT = (TCM_FIRST + 40);
		private struct RECT
		{
			public Int32 Left;
			public Int32 Top;
			public Int32 Right;
			public Int32 Bottom;
		}
	}
}
