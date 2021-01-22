    string retVal = "";
                // Can't change the 'Host' header property because .NET protects it
                // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // request.Headers.Set(HttpRequestHeader.Host, DEPLOYER_HOST);
                // so we must use a workaround
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Proxy = new WebProxy(ip);
                using (WebResponse response = request.GetResponse())
                {
                    using (TextReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            retVal += line;
                    }
                }
                return retVal;
