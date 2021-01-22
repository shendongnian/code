	public partial class MyForm : Form
	{
		private MyModel Model;
		public MyForm(MyModel model)
		{
			InitializeComponent();
			Model = model;
			// Create our bindings
			dtpDate.DataBindings.Add(new Binding("Value", Model,
				this.GetPropertyName((MyModel x) => x.ProxyWhenDate)));
			dtpTime.DataBindings.Add(new Binding("Value", Model,
				this.GetPropertyName((MyModel x) => x.ProxyWhenTime)));
		}
	}
