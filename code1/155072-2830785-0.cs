    public string SetStream(string astring, string bstring)
    {
        using (var client = new WebClient())
        {
            var values = new NameValueCollection() {
                "astring", astring,
                "bstring", bstring
            };
            var result = client.UploadValues(
                "http://localhost/api.php", 
                "GET",
                values
            );
            return Encoding.Default.GetString(result);
        }
    }
