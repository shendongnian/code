	public class MyControl : UserControl
	{
		public static readonly DependencyProperty MyText1Property =
			DependencyProperty.Register("MyText1", typeof(string),
			typeof(MyControl), new UIPropertyMetadata(""));
		public string MyText1
		{
			get { return (string)GetValue(MyText1Property); }
			set { SetValue(MyText1Property, value); }
		}
		public static readonly DependencyProperty MyText2Property =
			DependencyProperty.Register("MyText2", typeof(string),
			typeof(MyControl), new UIPropertyMetadata(""));
		public string MyText2
		{
			get { return (string)GetValue(MyText2Property); }
			set { SetValue(MyText2Property, value); }
		}
		public static readonly DependencyProperty MyText3Property =
			DependencyProperty.Register("MyText3", typeof(string),
			typeof(MyControl), new UIPropertyMetadata(""));
		public string MyText3
		{
			get { return (string)GetValue(MyText3Property); }
			set { SetValue(MyText3Property, value); }
		}
	}
