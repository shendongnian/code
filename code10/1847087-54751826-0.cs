	public void OnActionCallback(Office.IRibbonControl control, bool isPressed)
	{
		if (control.Id == "checkBox1")
		{
			MessageBox.Show("You clicked " + control.Id);
		}
		else
		{
			MessageBox.Show("You clicked a different control.");
		}
	}
