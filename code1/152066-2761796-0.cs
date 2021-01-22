    public class MyClass : FrameworkElement
	{
		public static readonly DependencyProperty Num1Property =
			DependencyProperty.Register("Num1", typeof(string), typeof(MyClass));
		public static readonly DependencyProperty Num2Property =
			DependencyProperty.Register("Num2", typeof(string), typeof(MyClass));
		public string Num1
		{
			get { return (string)GetValue(Num1Property); }
			set { SetValue(Num1Property, value); }
		}
		public string Num2
		{
			get { return (string)GetValue(Num2Property); }
			set { SetValue(Num2Property, value); }
		}
	}
