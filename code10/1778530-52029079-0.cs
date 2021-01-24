    public class YahooCurrencyService : ICurrencyService
    {
        private string endpointUrl;
        private IYahooAuthenticator authenticator;
        public decimal Convert(decimal amount, CurrencyDTO fromCurrency, CurrencyDTO toCurrency)
        {
            using (var httpClient = new HttpClientOfYourChoice())
            {
                try
                {
                    // Doing http work
                    httpClient.PutHeaderValues(authenticator.GetHeaderValues());
                    httpClient.Url = string.Format("{0}/{1}/{2}?amount={3}", endpointUrl, fromCurrency.Name, toCurrency.Name, amount);
                    var response = httpClient.Get();
                }
                catch
                {
                    // Exception handling
                }
            }
        }
    }
