    public partial class DataBindingChain : Window
	{
		public MyClass MyClass
		{
			get;
			set;
		}
		public DataBindingChain()
		{
			MyClass = new MyClass();
			InitializeComponent();
			Binding binding1 = new Binding("Num1")
			{
				Source = MyClass,
				Mode = BindingMode.OneWay
			};
			Binding binding2 = new Binding("Text")
			{
				Source = tb,
				Mode = BindingMode.OneWay
			};
			tb.SetBinding(TextBlock.TextProperty, binding1);
			MyClass.SetBinding(MyClass.Num2Property, binding2);
			var timer = new Timer(500) { Enabled = true, };
			timer.Elapsed += (sender, args) => Dispatcher.Invoke(UpdateAction, MyClass);
			timer.Start();
		}
		Action<MyClass> UpdateAction = (myClass) => { myClass.Num1 += "a"; };
	}
