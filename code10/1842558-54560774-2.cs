		private void OnInit(object sender, RoutedEventArgs e)
		{
			this.DataContext = new MachineItem("Type your description here",
				MachineTypeEnum.Computer, "1.1.1.1", "1.1.1.1", 4, null, ((GUIApp)Application.Current).CurrentMachineGroup,
				BordersStyle.Blue);
			var buttons = VisualTreeHelperExtensions.FindChild<Button>(this, "DeleteButton");
			foreach (var button in buttons)
			{
				button.Visibility = Visibility.Hidden;
			}
		}
