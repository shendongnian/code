    public partial class Window1 : Window
	{
		public bool IsCheckedOut
		{
			get { return (bool)GetValue(IsCheckedOutProperty); }
			set { SetValue(IsCheckedOutProperty, value); }
		}
		public static readonly DependencyProperty IsCheckedOutProperty = DependencyProperty.Register("IsCheckedOut", typeof(bool), typeof(Window1), new PropertyMetadata(false));
		public Window1()
		{
			InitializeComponent();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			IsCheckedOut = !IsCheckedOut;
		}
	}
