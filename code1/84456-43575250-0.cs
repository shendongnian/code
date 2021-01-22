    public static string Getpublicip()
        {
            try
            {
                string externalIP = "";
                var request = (HttpWebRequest)WebRequest.Create("http://icanhazip.com.ipaddress.com/");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                externalIP = new WebClient().DownloadString("http://icanhazip.com");
                return externalIP;
            }
            catch (Exception e)
            {
                return "null";
            }
        }
