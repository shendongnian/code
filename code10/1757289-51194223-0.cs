    public string GetAPIJsonAsync(string URL)
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(URL);
            }
        }
