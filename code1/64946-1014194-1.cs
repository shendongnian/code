    	public partial class LabelTextBox : UserControl
	{
		public LabelTextBox()
		{
			InitializeComponent();
			Label = "Label";
			Text = "Text";
		}
		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(LabelTextBox), new FrameworkPropertyMetadata(LabelPropertyChangedCallback));
		private static void LabelPropertyChangedCallback(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
		{
		}
		public string Label
		{
			get { return (string) GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(LabelTextBox), new FrameworkPropertyMetadata(TextPropertyChangedCallback));
		private static void TextPropertyChangedCallback(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
		{
		}
		public string Text
		{
			get { return (string) GetValue(TextProperty); }
			set { SetValue(LabelTextBox.TextProperty, value); }
		}
	}
