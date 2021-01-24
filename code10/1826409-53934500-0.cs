    using System;
    using System.Net.Http;
    using System.Text;
    
    namespace httpClient
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                using (var client = new HttpClient() {BaseAddress = new Uri("https://sprzedajemy.pl")})
                {
                    client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");
                    client.DefaultRequestHeaders.Add("accept-language", "pl,en-US;q=0.9,en;q=0.8,ru;q=0.7");
                    client.DefaultRequestHeaders.Add("origin", "https://sprzedajemy.pl");
                    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    var postData = "_rp_offerID=80e158b0281e04a2102fd7bce6eba0cd3833";
    
                    var stringContent = new StringContent(postData, Encoding.Default, "application/x-www-form-urlencoded");
    
                    var result = client.PostAsync("oferta-dane.telefon", stringContent).GetAwaiter().GetResult();
                }
            }
        }
    }
