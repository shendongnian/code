    private void ClearControl( Control control )
	{
		var textbox = control as TextBox;
		if (textbox != null)
			textbox.Text = string.Empty;
		var dropDownList = control as DropDownList;
		if (dropDownList != null)
			dropDownList.SelectedIndex = 0;
		// handle any other control //
		foreach( Control childControl in control.Controls )
		{
			ClearControl( childControl );
		}
	}
