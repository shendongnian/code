    public class Program
    {
            static async Task Main(string[] args)
            {
                string baseURL = "xxxxx";
                string UserName = "xxxx";
                string Password = "xxxxx";
                string api_key = "xxxxx";
                string api_token = "";
    
                string token = await GetToken(baseURL, UserName, Password, api_key);
            }
    
            async static Task<string> GetToken(string url, string username, string password, string apikey)
            {
                string token = string.Empty;
    
                using (HttpClient client = new HttpClient())
                {
                    TokenRequestor tokenRequest = new TokenRequestor(apikey, username, password);
                    string JSONresult = JsonConvert.SerializeObject(tokenRequest);
                    HttpContent c = new StringContent(JSONresult, Encoding.UTF8, "application/json");
                    HttpResponseMessage message = await client.PostAsync(url, c);    
                    string tokenJSON = await message.Content.ReadAsStringAsync();   
                    string pattern = "token\":\"([a-z0-9]*)";
                    Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
                    Match m = myRegex.Match(tokenJSON);
                    String string_m = m.ToString();
                    char[] chars = { ':' };
                    string[] matches = string_m.Split(chars);
                    string final_match = matches[1].Trim(new Char[] { '"' });
                    token = final_match;
                }
    
                return token;
            }
    
    
            public class TokenRequestor
            {
    
                public string method;
                public string module;
                public string key;
                public RequestMaker request;
    
                public TokenRequestor(string apikey, string Name, string pwd)
                {
                    method = "get";
                    module = "api.login";
                    key = apikey;
                    request = new RequestMaker(Name, pwd);
                }
    
    
            }
    
            public class RequestMaker
            {
                public string username;
                public string password;
    
                public RequestMaker(string uname, string pwd)
                {
                    username = uname;
                    password = pwd;
    
                }        
            }
    }
