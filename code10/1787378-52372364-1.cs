	public partial class MyTestPage : ContentPage
	{
		private string myStringProperty;
		public string MyStringProperty
		{
			get { return myStringProperty; }
			set 
			{
				myStringProperty = value;
				OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
			}
		}
		
		public MyTestPage()
		{
			InitializeComponents();
			BindingContext = this;
            MyTextProperty = "New label text"; // It will be shown at your label
		}
	}
