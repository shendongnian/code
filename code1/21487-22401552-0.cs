        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "?disco");
        request.ClientCertificates.Add(
          new X509Certificate2(@"c:\mycertpath\mycert.pfx", "<privatekeypassword>")); // If server requires client certificate
        request.Timeout = 300000; // 5 minutes
        using (WebResponse response = request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
        {
          XmlDocument xd = new XmlDocument();
          xd.LoadXml(sr.ReadToEnd());
          return xd.DocumentElement.ChildNodes.Count > 0;
        }
