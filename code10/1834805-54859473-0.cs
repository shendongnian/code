    //Here Is The Working Code :
    
    public class YWSample
    {
        const string cURL = "https://weather-ydn-yql.media.yahoo.com/forecastrss";
        const string cAppID = "Your-App-ID";
        const string cConsumerKey = "Your-Consumer-Key";
        const string cConsumerSecret = "Your-Consumer-Secret";
        const string cOAuthVersion = "1.0";
        const string cOAuthSignMethod = "HMAC-SHA1";
        const string cWeatherID = "woeid=727232";  // Amsterdam, The Netherlands
        const string cUnitID = "u=c";           // Metric units
        const string cFormat = "xml";
    
        //Code to get timestamp
        static string _get_timestamp()
        {
            var lTS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(lTS.TotalSeconds).ToString();
        }  
    
        //Code to get nonce
        static string _get_nonce()
        {
            return Convert.ToBase64String(
             new ASCIIEncoding().GetBytes(
              DateTime.Now.Ticks.ToString()
             )
            );
        }  // end _get_nonce
    
        static string _get_auth()
        {
            var lNonce = _get_nonce();
            var lTimes = _get_timestamp();
            var lCKey = string.Concat(cConsumerSecret, "&");
            var lSign = $"format={cFormat}&" + $"oauth_consumer_key={cConsumerKey}&" + $"oauth_nonce={lNonce}&" +
                           $"oauth_signature_method={cOAuthSignMethod}&" + $"oauth_timestamp={lTimes}&" +
                           $"oauth_version={cOAuthVersion}&" + $"{cUnitID}&{cWeatherID}";
    
            lSign = string.Concat(
             "GET&", Uri.EscapeDataString(cURL), "&", Uri.EscapeDataString(lSign)
            );
    
            using (var lHasher = new HMACSHA1(Encoding.ASCII.GetBytes(lCKey)))
            {
                lSign = Convert.ToBase64String(
                 lHasher.ComputeHash(Encoding.ASCII.GetBytes(lSign))
                );
            }  // end using
    
            return "OAuth " +
                   "oauth_consumer_key=\"" + cConsumerKey + "\", " +
                   "oauth_nonce=\"" + lNonce + "\", " +
                   "oauth_timestamp=\"" + lTimes + "\", " +
                   "oauth_signature_method=\"" + cOAuthSignMethod + "\", " +
                   "oauth_signature=\"" + lSign + "\", " +
                   "oauth_version=\"" + cOAuthVersion + "\"";
    
        }  // end _get_auth
    
        public static void Main(string[] args)
        {
            const string lURL = cURL + "?" + cWeatherID + "&" + cUnitID + "&format=" + cFormat;
    
            var lClt = new WebClient();
    
            lClt.Headers.Set("Content-Type", "application/" + cFormat);
            lClt.Headers.Add("Yahoo-App-Id", cAppID);
            lClt.Headers.Add("Authorization", _get_auth());
    
            Console.WriteLine("Downloading Yahoo weather report . . .");
    
            var lDataBuffer = lClt.DownloadData(lURL);
    
            var lOut = Encoding.ASCII.GetString(lDataBuffer);
    
            Console.WriteLine(lOut);
    
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }//end of Main
    
    }  // end YWSample 
