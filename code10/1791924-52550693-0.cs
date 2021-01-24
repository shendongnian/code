    public partial class StackOverflowTest : ContentPage
	{
		public StackOverflowTest()
		{
			InitializeComponent();
			string strvalue = "Delete";
			BtnTest.Clicked += delegate (object sender2, EventArgs e2)
			{
				DeleteActionHandler(sender2, e2, strvalue);
			};
		}
		private void DeleteActionHandler(object sender, EventArgs e, string strval)
		{
			DisplayAlert("Greeting", $"{strval}!", "Ok");
		}
	}
