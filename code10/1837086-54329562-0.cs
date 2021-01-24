      static string GetToken(string url, string username, string password, string apikey)
        {
            using (HttpClient client = new HttpClient())
            {
                TokenRequestor tokenRequest = new TokenRequestor(apikey, username, password);
                string JSONresult = JsonConvert.SerializeObject(tokenRequest);
                HttpContent c = new StringContent(JSONresult, Encoding.UTF8, "application/json");
                //Console.WriteLine(JSONresult);
                HttpResponseMessage message =  client.PostAsync(url, c).Result;
                // Console.WriteLine(await message.Content.ReadAsStringAsync());
                string tokenJSON =  message.Content.ReadAsStringAsync().Result;
                string pattern = "token\":\"([a-z0-9]*)";
                Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
                Match m = myRegex.Match(tokenJSON);
                String string_m = m.ToString();
                char[] chars = { ':' };
                string[] matches = string_m.Split(chars);
                string final_match = matches[1].Trim(new Char[] { '"' });
                string token = final_match;
                Console.WriteLine(token); //just for testing purposes to make sure i'm getting the data I want. 
                return token;
            }
        }
