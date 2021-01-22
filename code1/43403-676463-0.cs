    WebProxy p = new WebProxy ("192.168.10.01", true);
    p.Credentials = new NetworkCredential ("username", "password", "domain");
    using (WebClient wc = new WebClient())
    {
      wc.Proxy = p;
      ...
    }
