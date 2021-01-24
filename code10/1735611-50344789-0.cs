	public void OptionSelect_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		var option = OptionSelect.SelectedItem;
		// Prevent setting the SelectedItem from refiring event
		OptionSelect.SelectedIndexChanged -= OptionSelect_OnSelectedIndexChanged;
		OptionSelect.SelectedItem = null;
		OptionSelect.SelectedIndexChanged += OptionSelect_OnSelectedIndexChanged;
		// Do something with option object
	}
