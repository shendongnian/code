    <RichTextBox x:Name="logTextBox" PreviewMouseWheel="LogTextBox_PreviewMouseWheel" />
	private void LogTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (Keyboard.Modifiers != ModifierKeys.Control)
		{
			return;
		}
		e.Handled = true;
		if (e.Delta > 0)
		{
			++logTextBox.FontSize;
		}
		else
		{
			--logTextBox.FontSize;
		}
	}
