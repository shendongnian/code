    public static class ExtensionFocus
		{
		static ExtensionFocus()
			{
			BoundElements = new List<string>();
			}
		public static readonly DependencyProperty IsFocusedProperty =
			DependencyProperty.RegisterAttached("IsFocused", typeof(bool?),
			typeof(ExtensionFocus), new FrameworkPropertyMetadata(false, IsFocusedChanged));
		private static List<string> BoundElements;
		public static bool? GetIsFocused(DependencyObject element)
			{
			if (element == null)
				{
				throw new ArgumentNullException("ExtensionFocus GetIsFocused called with null element");
				}
			return (bool?)element.GetValue(IsFocusedProperty);
			}
		public static void SetIsFocused(DependencyObject element, bool? value)
			{
			if (element == null)
				{
				throw new ArgumentNullException("ExtensionFocus SetIsFocused called with null element");
				}
			element.SetValue(IsFocusedProperty, value);
			}
		private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
			var fe = (FrameworkElement)d;
			// OLD LINE:
			// if (e.OldValue == null)
			// TWO NEW LINES:
			if (BoundElements.Contains(fe.Name) == false)
				{
				BoundElements.Add(fe.Name);
				fe.LostFocus += OnLostFocus;
				fe.GotFocus += OnGotFocus;
				}			
			if (!fe.IsVisible)
				{
				fe.IsVisibleChanged += new DependencyPropertyChangedEventHandler(fe_IsVisibleChanged);
				}
			if ((bool)e.NewValue)
				{
				fe.Focus();				
				}
			}
		private static void fe_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
			{
			var fe = (FrameworkElement)sender;
			if (fe.IsVisible && (bool)((FrameworkElement)sender).GetValue(IsFocusedProperty))
				{
				fe.IsVisibleChanged -= fe_IsVisibleChanged;
				fe.Focus();
				}
			}
		private static void OnLostFocus(object sender, RoutedEventArgs e)
			{
			if (sender != null && sender is Control s)
				{
				s.SetValue(IsFocusedProperty, false);
				}
			}
		private static void OnGotFocus(object sender, RoutedEventArgs e)
			{
			if (sender != null && sender is Control s)
				{
				s.SetValue(IsFocusedProperty, true);
				}
			}
		}
			
