    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            WebView webView = new WebView
            {
                // elided
            };
            /* ViewModel.Pages.MainPageViewModel vm = new ViewModel.Pages.MainPageViewModel();
             this.BindingContext = vm;*/
        }
