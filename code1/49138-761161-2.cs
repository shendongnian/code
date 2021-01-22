	public partial class Window1 : Window
	{
		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size",
			typeof(Size),
			typeof(Window1));
		public Size Size
		{
			get { return (Size)GetValue(SizeProperty); }
			set { SetValue(SizeProperty, value); }
		}
		public Window1()
		{
			InitializeComponent();
			DataContext = this;
			_button.Click += new RoutedEventHandler(_button_Click);
		}
		void _button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(Size.ToString());
		}
	}
