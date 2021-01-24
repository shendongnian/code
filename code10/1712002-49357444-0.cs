            string pageSource1 = null, pageSource2 = null, pageSource3 = null;
            try
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    // perhaps fake user agent?
                    webClient.Headers.Add("USER_AGENT", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36 OPR/51.0.2830.55");
                    //
                    // option 1: using webclient download string (simple call)
                    pageSource1 = webClient.DownloadString(url);
                    //
                    // option 2: getting a stream... (if you prefer using a stream, eg. not reading the whole page until the end)
                    var webClientStream = webClient.OpenRead(url);
                    if (webClientStream != null)
                    {
                        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(webClientStream))
                        {
                            pageSource2 = streamReader.ReadToEnd();
                        }
                    }
                }
                //
                // option3: using webrequest (with webrequest/webresponse you can rebuild the browser behavior eg. walking pages)
                System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
                webRequest.Method = "GET";
                var webResponse = webRequest.GetResponse();
                var webResponseStream = webResponse.GetResponseStream();
                if (webResponseStream != null)
                {
                    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(webResponseStream))
                    {
                        pageSource3 = streamReader.ReadToEnd();
                    }
                }
            }
            catch (System.Net.WebException exc)// for web
            {
                Console.WriteLine($"Unable to download page source: {exc.Message}");
                // todo - safely handle...
            }
            catch (System.IO.IOException exc)//for stream
            {
                Console.WriteLine($"Unable to download page source: {exc.Message}");
                // todo - safely handle...
            }
