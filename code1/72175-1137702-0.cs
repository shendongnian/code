	private void theComboBox_OnGotFocus(object sender, RoutedEventArgs e)
	{
		ComboBox theComboBox = sender as ComboBox;
		if (comboBox != null)
		{
			MultiBindingExpression binding = BindingOperations.GetMultiBindingExpression(theComboBox, ComboBox.ItemsSourceProperty);
			if (binding != null)
			{
				binding.UpdateTarget();
			}
		}
	}
