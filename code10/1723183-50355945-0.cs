    var client = new HttpClient();
    client.DefaultRequestHeaders.Clear();
    string s = null;
    var result = await client.GetAsync("http://google.pl");
    using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync(), Encoding.GetEncoding("iso-8859-1")))
    {
         s = sr.ReadToEnd();
    }
