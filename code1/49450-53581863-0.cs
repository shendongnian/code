	/// <summary>
	/// Stop resizing of the Form from selecting ComboBox's text.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	/// <remarks>Used for all ComboBox'es</remarks>
	private void cbo_Resize(object sender, EventArgs e)
	{
		((ComboBox)sender).Select(0, 0);
	}
