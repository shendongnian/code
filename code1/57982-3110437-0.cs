            string DestAddr = "http://mydestination.com";
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            WebProxy myProxy = new WebProxy();
            myProxy.IsBypassed(new Uri(DestAddr));
            myWebClient.Proxy = myProxy;
            return myWebClient.DownloadString(DestAddr);
}
