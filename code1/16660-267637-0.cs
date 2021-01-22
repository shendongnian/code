	public partial class Window1 : Window
	{
		public MyClass2 MyClass2Object { get; set; }
		public Window1()
		{
			// use data context instead of source
			DataContext = this;
			InitializeComponent();
			MyClass2Object = new MyClass2();
			Binding binding = new Binding();
			binding.Path = new PropertyPath("MyClass2Object.StringVar");
			TextBoxFromXaml.SetBinding(TextBox.TextProperty, binding);
		}
	}
	public class MyClass2
	{
		public string StringVar { get; set; }
		public MyClass2()
		{
			StringVar = "My String Here";
		}
	}
