    public class GettingWords
    {
        private static HttpClient _client = new HttpClient();
        public async Task<string>  GettingWordAsync(string word, string adress)
        {
            string result;
            string data = await _client.GetStringAsync(adress);
            string pattern = word;
    
            // Instantiate the regular expression object.
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
    
            // Match the regular expression pattern against your html data.
            Match m = r.Match(data);
    
            if (m.Success)
            {
                result = "Word  " + word + "  finded in  " + adress;
            }
            else
            {
                result = "Word not finded";
            }
            return result;
    
        }
    }
