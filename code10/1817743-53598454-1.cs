	public static class LastSelectedItemBehavior
	{
		public static readonly DependencyProperty ExposeLastSelectedItemProperty =
			DependencyProperty.RegisterAttached("ExposeLastSelectedItem", typeof(bool), typeof(LastSelectedItemBehavior),
				new PropertyMetadata(false, ExposeLastSelectedItemChanged));
		public static bool GetExposeLastSelectedItem(ListBox element)
		{
			return (bool)element.GetValue(ExposeLastSelectedItemProperty);
		}
		public static void SetExposeLastSelectedItem(ListBox element, bool value)
		{
			element.SetValue(ExposeLastSelectedItemProperty, value);
		}
		private static void ExposeLastSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ListBox listBox && e.NewValue is bool boolValue)
			{
				if (boolValue)
				{
					listBox.SelectionChanged += ListBox_SelectedItemsChanged;
				}
				else
				{
					listBox.SelectionChanged -= ListBox_SelectedItemsChanged;
				}
			}
		}
		private static void ListBox_SelectedItemsChanged(object sender, SelectionChangedEventArgs e)
		{
			var listBox = (ListBox) sender;
			listBox.SetValue(LastSelectedItemPropertyKey, listBox.SelectedItems.Count > 0 ? listBox.SelectedItems[listBox.SelectedItems.Count - 1] : default(object));
		}
		private static readonly DependencyPropertyKey LastSelectedItemPropertyKey =
			DependencyProperty.RegisterAttachedReadOnly(
				"LastSelectedItem", 
				typeof(object), 
				typeof(LastSelectedItemBehavior),
				new PropertyMetadata(default(object)));
		public static readonly DependencyProperty LastSelectedItemProperty = LastSelectedItemPropertyKey.DependencyProperty;
		public static object GetLastSelectedItem(ListBox element)
		{
			return element.GetValue(LastSelectedItemProperty);
		}
	}
