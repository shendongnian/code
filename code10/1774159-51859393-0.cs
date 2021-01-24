      public async Task<string> GettingWordAsync(string word, string adress)
        {
            HttpWebRequest req = WebRequest.CreateHttp(adress);
            req.Method = "GET";
            req.KeepAlive = true;   
            string result;
            string content = null;
            string pattern = word;
            HttpStatusCode code = HttpStatusCode.OK;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        content = await sr.ReadToEndAsync();
                    
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        content = sr.ReadToEnd();
                    code = response.StatusCode;
                }
            }
                    // Instantiate the regular expression object.
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            // Match the regular expression pattern against your html data.
            Match m = r.Match(content);
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
