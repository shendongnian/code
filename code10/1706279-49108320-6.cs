	public AddSelected(IList list, params ComboBox[] comboBoxes)
	{
		foreach (var comboBox in comboBoxes)
		{
			if (comboBox.SelectedIndex >= 0)
			{
				list.Add(comboBox.SelectedItem.ToString());
			}
		}
	}
