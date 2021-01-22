        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        string[] proxyArray = proxyHostAndPort.Split(':');
        WebProxy proxyz = new WebProxy(proxyArray[0], int.Parse(proxyArray[1]));
        request.Proxy = proxyz;
        using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string str = reader.ReadToEnd();
            }
        }
