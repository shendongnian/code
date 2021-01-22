	public static class TextBoxClearBehavior
	{
		public static readonly DependencyProperty TextBoxClearProperty =
			DependencyProperty.RegisterAttached(
				"TextBoxClear",
				typeof(bool),
				typeof(TextBoxClearBehavior),
				new UIPropertyMetadata(false, OnTextBoxClearPropertyChanged));
		public static bool GetTextBoxClear(DependencyObject obj)
		{
			return (bool)obj.GetValue(TextBoxClearProperty);
		}
		public static void SetTextBoxClear(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxClearProperty, value);
		}
		private static void OnTextBoxClearPropertyChanged(
			DependencyObject d,
			DependencyPropertyChangedEventArgs args)
		{
			if ((bool)args.NewValue == false)
			{
				return;
			}
			var textBox = (TextBox)d;
			textBox?.Clear();
		}
	}	
