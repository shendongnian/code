    CookieContainer CookieJar = new CookieContainer();
    public async Task<string> GetHttpStream(Uri HtmlPage)
    {
        HttpWebRequest httpRequest;
        string Payload = string.Empty;
        httpRequest = WebRequest.CreateHttp(HtmlPage);
        try
        {
            httpRequest.CookieContainer = CookieJar;
            httpRequest.KeepAlive = true;
            httpRequest.ConnectionGroupName = Guid.NewGuid().ToString();
            httpRequest.AllowAutoRedirect = true;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpRequest.ServicePoint.MaxIdleTime = 30000;
            httpRequest.ServicePoint.Expect100Continue = false;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0";
            httpRequest.Accept = "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            httpRequest.Headers.Add(HttpRequestHeader.AcceptLanguage, "es-ES,es;q=0.8,en-US;q=0.5,en;q=0.3");
            httpRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate;q=0.8");
            httpRequest.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync())
            {
                Stream ResponseStream = httpResponse.GetResponseStream();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        //ResponseStream.Position = 0;
                        Encoding encoding = Encoding.GetEncoding(httpResponse.CharacterSet);
                        using (MemoryStream _memStream = new MemoryStream())
                        {
                            if (httpResponse.ContentEncoding.Contains("gzip"))
                            {
                                using (GZipStream _gzipStream = new GZipStream(ResponseStream, System.IO.Compression.CompressionMode.Decompress))
                                {
                                    _gzipStream.CopyTo(_memStream);
                                };
                            }
                            else if (httpResponse.ContentEncoding.Contains("deflate"))
                            {
                                using (DeflateStream _deflStream = new DeflateStream(ResponseStream, System.IO.Compression.CompressionMode.Decompress))
                                {
                                    _deflStream.CopyTo(_memStream);
                                };
                            }
                            else
                            {
                                ResponseStream.CopyTo(_memStream);
                            }
                            _memStream.Position = 0;
                            using (StreamReader _reader = new StreamReader(_memStream, encoding))
                            {
                                Payload = _reader.ReadToEnd().Trim();
                            };
                        };
                    }
                    catch (Exception)
                    {
                        Payload = string.Empty;
                    }
                }
            }
        }
        catch (WebException exW)
        {
            if (exW.Response != null)
            {
                //Handle WebException
            }
        }
        catch (System.Exception exS)
        {
            //Handle System.Exception
        }
        CookieJar = httpRequest.CookieContainer;
        return Payload;
    }
