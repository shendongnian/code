    Uri url = new Uri("https://www.86tempobet.com?reloadlive=240671122&no_write_sess=1");
    System.Net.WebClient client = new System.Net.WebClient();
    client.Headers.Add ("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
    client.Headers.Add("method","POST");
    client.Headers.Add("cookie","{cookie}");
    
    string jsonOneXBetData = client.DownloadString(url);
