    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SomeClass.GetJson();
        }
    }
    public class SomeClass
    {
        public static async Task<double> GetJson()
        {
            using (var httpClient = new HttpClient())
            {
                Uri uri = new Uri("https://api.cryptonator.com/api/ticker/btc-usd");
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                return 1.2;
            }
        }
    }
