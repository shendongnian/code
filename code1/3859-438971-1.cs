	// file 'MyForm.cs' in C:\TEMP\PshWindow
	using System;
	using System.Drawing;
	using System.Threading;
	using System.Windows.Forms;
	namespace PshWindow
	{
		internal sealed class MyForm : Form
		{
			public MyForm(object sync)
			{
				this._sync = sync;
				this.BackColor = Color.LightGreen;
				this.Width = 200;
				this.Height = 80;
				this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			}
			protected override void OnShown(EventArgs e)
			{
				base.OnShown(e);
				this.TopMost = true;
				lock (this._sync)
				{
					Monitor.PulseAll(this._sync);
				}
			}
			private readonly object _sync;
		}
	}
