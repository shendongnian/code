	private void theComboBox_OnGotFocus(object sender, RoutedEventArgs e)
	{
		ComboBox theComboBox = sender as ComboBox;
		if (theComboBox != null)
		{
			MultiBindingExpression binding = BindingOperations.GetMultiBindingExpression(theComboBox, ComboBox.ItemsSourceProperty);
			if (binding != null)
			{
				binding.UpdateTarget();
			}
		}
	}
