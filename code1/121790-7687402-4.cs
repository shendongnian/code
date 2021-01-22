	public partial class ClickToEditTextboxControl : UserControl
	{
		public ClickToEditTextboxControl()
		{
			InitializeComponent();
		}
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(ClickToEditTextboxControl), new UIPropertyMetadata());
		private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
		{
			var txtBlock = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];
			txtBlock.Visibility = Visibility.Visible;
			((TextBox)sender).Visibility = Visibility.Collapsed;
		}
		private void textBlockName_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var grid = ((Grid) ((TextBlock) sender).Parent);
            var tbx = (TextBox)grid.Children[1];
            ((TextBlock)sender).Visibility = Visibility.Collapsed;
            tbx.Visibility = Visibility.Visible;
            this.Dispatcher.BeginInvoke((Action)(() => Keyboard.Focus(tbx)), DispatcherPriority.Render);
		}
        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;
            if (e.Key == Key.Return)
            {
                TextBoxLostFocus(sender, null);
            }
        }
	}
