    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TradeSatoshi.Console
    {
        public class TradeSatoshiResponse<T>
        {
            [JsonProperty(PropertyName = "success")]
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            [JsonProperty(PropertyName = "result")]
            public T Data { get; set; }
        }
    
        /// <summary>
        /// A <see cref="BalanceInfo"/> instance is one returned from the  https://tradesatoshi.com/api/private/getbalance URI
        /// </summary>
        public class BalanceInfo
        {
            public string Currency { get; set; }
            [JsonProperty(PropertyName = "CurrencyLong")]
            public string CurrencyLongName { get; set; }
            public decimal Available { get; set; }
            public decimal Total { get; set; }
            public decimal HeldForTrades { get; set; }
            public decimal Unconfirmed { get; set; }
            public decimal PendingWithdraw { get; set; }
            public string Address { get; set; }
    
            public override string ToString()
            {
                return $"Currency: {Currency}, CurrencyLongName: {CurrencyLongName}, Available: {Available}, Total: {Total}, HeldForTrades: {HeldForTrades}, Unconfirmed: {Unconfirmed}, PendingWithdrawl: {PendingWithdraw}, Address: {Address}";
            }
        }
    
        class StackExchangeQuestion
        {
            private const string PUBLIC_API_KEY = "your public key";
            private const string PRIVATE_API_KEY = "your private key";
    
            public static async Task GetBalance(string Currency)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var uri = new Uri("https://tradesatoshi.com/api/private/getbalances");
                        string nonce = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                        JObject post_params = new JObject();
                        post_params.Add("Currency", "BTC"); //not needed for getbalances, but I left it in here to show how post params would be used
                        string serializedParms = JsonConvert.SerializeObject(post_params);
                        string signature = CreateSignature(uri, serializedParms, nonce);
                        var content = CreateHttpContent(serializedParms);
                        var request = CreateHttpRequestMessage(uri, signature, content, nonce);
                        var result = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<TradeSatoshiResponse<IList<BalanceInfo>>>(result);
                        var balance = ((IList<BalanceInfo>)response.Data).Single(x => x.Currency == "BTC");
                        System.Console.WriteLine(balance);
    
                    }
                    catch (Exception e) { throw e; };
                }
            }
    
            public static string CreateSignature(Uri uri, string parameters, string nonce)
            {
                //SIGNATURE: API_KEY + "POST" + URI + NONCE + POST_PARAMS(signed by secret key according to HMAC - SHA512 method.)
                string endpoint = WebUtility.UrlEncode(uri.ToString()).ToLower();
                parameters = Convert.ToBase64String(Encoding.UTF8.GetBytes(parameters ?? ""));
                var signature = $"{PUBLIC_API_KEY}POST{endpoint}{nonce}{parameters}";
                using (var hashAlgo = new HMACSHA512(Convert.FromBase64String(PRIVATE_API_KEY)))
                {
                    var signedBytes = hashAlgo.ComputeHash(Encoding.UTF8.GetBytes(signature));
                    return Convert.ToBase64String(signedBytes);
                }
            }
    
            public static HttpContent CreateHttpContent(string jsonParams)
            {
                return new StringContent(jsonParams ?? "", Encoding.UTF8, "application/json");
            }
    
            public static HttpRequestMessage CreateHttpRequestMessage(Uri uri, string signature, HttpContent content, string nonce)
            {
                var header = $"Basic {PUBLIC_API_KEY}:{signature}:{nonce}";
                var message = new HttpRequestMessage(HttpMethod.Post, uri);
                message.Headers.Add("Authorization", header);
                message.Content = content;
                return message;
            }
    
        }
    }
