	void _associatedObject_TextChanged(object sender, TextChangedEventArgs e)
	{
		if(e.NewTextValue == "test")
			((CheckableEntryView)sender).ShowValidationMessage();
		else
			((CheckableEntryView)sender).HideValidationMessage();
	}
