    public partial class MainPage : ContentPage
    {
       public MainPage()
       {
          InitializeComponent();
         SizeChanged += MainPageSizeChanged;
       }
 
       void MainPageSizeChanged(object sender, EventArgs e)
       {
          imgMonkey.WidthRequest = Math.Min(this.Width, 400);
       }
    }
