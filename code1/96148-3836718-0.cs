	public Form1()
	{
		InitializeComponent();
		KeyPreview = true;  // indicates that key events for controls on the form
							// should be registered with the form
		KeyUp += new KeyEventHandler(Form1_KeyUp);
	}
	void Form1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Modifiers == Keys.Control)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					MessageBox.Show("Ctrl + A was pressed!");
					// activeXControl.SelectAll();
					break;
				case Keys.C:
					MessageBox.Show("Ctrl + C was pressed!");
					// activeXControl.Copy();
					break;
				case Keys.V:
					MessageBox.Show("Ctrl + V was pressed!");
					// activeXControl.Paste();
					break;
			}
		}
	}
