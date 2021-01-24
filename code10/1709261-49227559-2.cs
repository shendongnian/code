    public partial class ExchangeRates : Form
    {
        public ExchangeRates()
        {
            InitializeComponent();
        }
        private const string InputUri = @"https://api.bitfinex.com/v2/ticker/tBTCUSD";
        private async void button1_Click(object sender, EventArgs e)
        {
            await GetTicker();
        }
        private static async Task<Ticker> GetTicker()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(InputUri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var array = content.Substring(1, content.Length - 2).Split(',');
                var output = new Ticker
                {
                    Frr = decimal.Parse(array[0].ToString()),
                    Bid = decimal.Parse(array[1].ToString())
                    // add other properties as required.
                };
                return output;
            }
            throw new Exception("Ticker exception.");
        }
    }
    public class Ticker
    {
        public decimal Frr { get; set; }
        public decimal Bid { get; set; }
        // include other properties from https://bitfinex.readme.io/v2/reference#rest-public-tickers
    }
