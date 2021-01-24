    private string getSourceCode(string url)
    {
        WebClient wc = new WebClient();
        WebProxy myproxy = new WebProxy("195.201.**.**:****", false, null, new NetworkCredential("******", "******"));
        wc.Proxy = myproxy; // THIS ONE WAS MISSING
        wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:62.0) Gecko/20100101 Firefox/62.0");
        string sourceCode = wc.DownloadString(url);
        return sourceCode;
    }
