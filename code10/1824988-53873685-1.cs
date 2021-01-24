    Uri ResourceURI = new Uri("https://www.nasdaq.com/de/symbol/aapl/dividend-history");
    string DestinationFile = "[Some Local File]";
    //The 32bit IE11 header is the User-agent used here
    public async Task HTTPDownload(Uri ResourceURI, DestinationFile)
    {
        CookieContainer CookieJar = new CookieContainer();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        ServicePointManager.ServerCertificateValidationCallback += (s, cert, ch, sec) => { return true; };
        ServicePointManager.DefaultConnectionLimit = 50;
        HttpWebRequest httpRequest = WebRequest.CreateHttp(ResourceURI);
        try
        {
            httpRequest.CookieContainer = CookieJar;
            httpRequest.AllowAutoRedirect = true;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpRequest.ServicePoint.Expect100Continue = false;
            httpRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; WOW32; Trident / 7.0; rv: 11.0) like Gecko";
            httpRequest.Accept = "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            httpRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate;q=0.8");
            httpRequest.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync())
            using (Stream ResponseStream = httpResponse.GetResponseStream())
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        int buffersize = 132072;
                        using (FileStream fileStream = File.Create(DestinationFile, buffersize, FileOptions.Asynchronous))
                        {
                            int read;
                            byte[] buffer = new byte[buffersize];
                            while ((read = await ResponseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read);
                            }
                        };
                    }
                    catch (DirectoryNotFoundException) { /* Log or throw */}
                    catch (PathTooLongException) { /* Log or throw */}
                    catch (IOException) { /* Log or throw */}
                }
            };
        }
        catch (WebException) { /* Log and message */} 
        catch (Exception) { /* Log and message */}
    }
