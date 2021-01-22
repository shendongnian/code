	public event EventHandler AddControl;
	private void RaiseAddControl()
	{
		if (AddControl!= null)
		{
			AddControl(this, EventArgs.Empty);
		}
	}
