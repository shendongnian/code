	public class BoolCursorBinder
	{
		public static bool GetBindTarget(DependencyObject obj) { return (bool)obj.GetValue(BindTargetProperty); }
		public static void SetBindTarget(DependencyObject obj, bool value) { obj.SetValue(BindTargetProperty, value); }
		public static readonly DependencyProperty BindTargetProperty =
				DependencyProperty.RegisterAttached("BindTarget", typeof(bool), typeof(BoolCursorBinder), new PropertyMetadata(false, OnBindTargetChanged));
		private static void OnBindTargetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement element = sender as FrameworkElement;
			if (element != null)
			{
				element.Cursor = (bool)e.NewValue ? Cursors.Wait : Cursors.Arrow;
			}
		}
	}
