    namespace Apka.View.Pages
    {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            WebView webView = new WebView
            {
                Source = new HtmlWebViewSource
                {
                    Html = @"<!DOCTYPE html><html><head><style>img { width:100%; }</style></head><body>" + App.strona + @"</body></html>",
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 1000,
                HeightRequest=1000
            };
            /* ViewModel.Pages.MainPageViewModel vm = new ViewModel.Pages.MainPageViewModel();
             this.BindingContext = vm;*/
        }
    }
    }
