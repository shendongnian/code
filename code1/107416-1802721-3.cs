    private void OnClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			VisualStateManager.GoToState(TestControl, "State1", true);
		}
		private void OnClickState2(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			TestControl.SetState();
		}
