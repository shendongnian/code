    private string GetPublicIpAddress()
            {
                var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");
    
                request.UserAgent = "curl"; // this simulate curl linux command
    
                string publicIPAddress;
    
                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        publicIPAddress = reader.ReadToEnd();
                    }
                }
    
                return publicIPAddress.Replace("\n", "");
            }
