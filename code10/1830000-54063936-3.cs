    public sealed partial class SecondPage : Page
    {
        public AppViewModel ViewModel => MainPage.Current.ViewModel;
        public SecondPage()
        {
            this.InitializeComponent();
        }
    }
