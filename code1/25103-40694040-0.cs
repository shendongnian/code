    using System;
    using System.Threading;
    using System.Windows.Forms;
	namespace Test_Application
	{
		class ReadOnlyComboBox : ComboBox
		{
			private bool _readOnly;
			private bool isLoading;
			private bool indexChangedFlag;
			private int lastIndex = -1;
			private string lastText = "";
			public ReadOnlyComboBox()
			{
			}
			public bool ReadOnly
			{
				get { return _readOnly; }
				set { _readOnly = value; }
			}
			protected override void OnDropDown (EventArgs e)
			{
				if (_readOnly)
				{
					DropDownHeight = 1;
					var t = new Thread(CloseDropDown);
					t.Start();
					return;
				}
				DropDownHeight = 106; //Insert this line.
				base.OnDropDown(e);
			}
			private delegate void CloseDropDownDelegate();
			private void WaitForDropDown()
			{
				if (InvokeRequired)
				{
					var d = new CloseDropDownDelegate (WaitForDropDown);
					Invoke(d);
				}
				else
				{
					DroppedDown = false;
				}
			}
			private void CloseDropDown()
			{
				WaitForDropDown();
			}
			protected override void OnMouseWheel (MouseEventArgs e)
			{
				if (!_readOnly) 
					base.OnMouseWheel(e);
			}
			protected override void OnKeyDown (KeyEventArgs e)
			{
				if (_readOnly)
				{
					switch (e.KeyCode)
					{
						case Keys.Back:
						case Keys.Delete:
						case Keys.Up:
						case Keys.Down:
							e.SuppressKeyPress = true;
							return;
					}
				}
				base.OnKeyDown(e);
			}
			protected override void OnKeyPress (KeyPressEventArgs e)
			{
				if (_readOnly)
				{
					e.Handled = true;
					return;
				}
				base.OnKeyPress(e);
			}
		}
	}
