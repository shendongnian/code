        private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			TextBox_SimPassword.IsEnabled = false;
			Label_SimPassword.IsEnabled = false;
		}
		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			TextBox_SimPassword.IsEnabled = true;
			Label_SimPassword.IsEnabled = true;
		}
