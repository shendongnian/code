         public void UpdateControl(string value)
	{
		if(InvokeRequired)
		{
			BeginInvoke(new UpdateControlDelegate(UpdateControl), value);
		}
		else
		{
			txtAddress.Text = value;
			txtValue.Text = value;
		}
	}
