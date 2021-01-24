    public class CoinbaseV2
    {
        private string APIKey;
        private string Secret;
        private const string URL_BASE = "https://api.coinbase.com";
        private const string URL_BASE_VERSION = URL_BASE + "/v2/";
        private const String GET = "GET";
        private const String POST = "POST";
        private const String PUT = "PUT";
        private const String DELETE = "DELETE";
        public CoinbaseV2(string inAPIKey, string inSecret)
        {
            APIKey = inAPIKey;
            Secret = inSecret;
        }
        public string GetUser()
        {
            return JsonRequest(URL_BASE_VERSION + "user", GET);
        }
        public string GetUserAccounts()
        {
            return JsonRequest(URL_BASE_VERSION + "accounts", GET);
        }
        private string JsonRequest(string url, string method)
        {
            // take care of any spaces in params
            url = Uri.EscapeUriString(url);
            string returnData = String.Empty;
            var webRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.ContentType = "application/json";
                string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.CurrentCulture);
                string body = "";
                string sigurl = url.Replace(URL_BASE,"");
                string signature = GenerateSignature(timestamp,method,sigurl,body,Secret);
                var whc = new WebHeaderCollection();
                whc.Add("CB-ACCESS-SIGN", signature);
                whc.Add("CB-ACCESS-TIMESTAMP", timestamp);
                whc.Add("CB-ACCESS-KEY", APIKey);
                whc.Add("CB-VERSION", "2017-08-07");
                webRequest.Headers = whc;
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        returnData = reader.ReadToEnd();
                    }
                }
            }
            return returnData;
        }
        //https://github.com/bchavez/Coinbase
        public static string GenerateSignature(string timestamp, string method, string url, string body, string appSecret)
        {
            return GetHMACInHex(appSecret, timestamp + method + url + body).ToLower();
        }
        internal static string GetHMACInHex(string key, string data)
        {
            var hmacKey = Encoding.UTF8.GetBytes(key);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            using (var hmac = new HMACSHA256(hmacKey))
            {
                var sig = hmac.ComputeHash(dataBytes);
                return ByteToHexString(sig);
            }
        }
        //https://stackoverflow.com/questions/311165/how-do-you-convert-a-byte-array-to-a-hexadecimal-string-and-vice-versa/14333437#14333437
        static string ByteToHexString(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            int b;
            for (int i = 0; i < bytes.Length; i++)
            {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(87 + b + (((b - 10) >> 31) & -39));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(87 + b + (((b - 10) >> 31) & -39));
            }
            return new string(c);
        }
    }
