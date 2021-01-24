    public partial class ExchangeRates : Form
    {
        public ExchangeRates()
        {
            InitializeComponent();
        }
        private const string InputUri = @"https://api.bitfinex.com/v1/ticker/ethusd";
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
                var output = JsonConvert.DeserializeObject<Ticker>(content);
                return output;
            }
            throw new Exception("Ticker exception.");
        }
    }
    public class Ticker
    {
        [DataMember(Name = "mid")]
        public decimal Mid { get; set; }
        [DataMember(Name = "bid")]
        public decimal Bid { get; set; }
        [DataMember(Name = "ask")]
        public decimal Ask { get; set; }
        // other properties
    }
