	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    StackLayout sl1 = this.FindByName<StackLayout>("myStackLayout");
		    sl1.GestureRecognizers.Add(
		        new TapGestureRecognizer()
		        {
		            Command = new Command(async () => {
		                // When this line hits, background is set...  
		                sl1.BackgroundColor = Color.FromHex("#e50000");
		                //this.Refresh(); << force Refresh UI function or something????
		                await Task.Delay(400);
		                // When this line hits, background is reset...  
		                sl1.BackgroundColor = Color.FromHex("#0be204");
		            })
		        });
		}
	}
