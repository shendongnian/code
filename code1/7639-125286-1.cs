    WebProxy wp = new WebProxy(Settings.Default.ProxyAddress);
    wp.Credentials = new NetworkCredential(Settings.Default.ProxyUsername, Settings.Default.ProxyPassword);
    WebClient wc = new WebClient();
    wc.Proxy = wp;
                
    MemoryStream ms = new MemoryStream(wc.DownloadData(url));
    XmlTextReader rdr = new XmlTextReader(ms);
    return XDocument.Load(rdr); 
