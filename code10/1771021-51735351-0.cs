    var statusDic = new Dictionary<HttpStatusCode, string>();
            Task<HttpResponseMessage> response;
            var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                Credentials = new NetworkCredential("root", "pass")
            });
            try
            {
                client.BaseAddress = new Uri($@"http://{dicPair.Value}/axis-cgi/param.cgi");
                while (true)
                {
                    response = client.GetAsync(Source.config);
                    if (response.Result.IsSuccessStatusCode)
                        break;
                    Task.Delay(5000);
                }
                statusDic.Add(response.Result.StatusCode, response.Result.ToString());
            }
            catch (WebException ex)
            {
                using (var sr =
                    new StreamReader(ex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    Logger.LogError($@"WEB EXCEPTION - {sr.ReadToEnd()}");
                    statusDic.Add(HttpStatusCode.BadRequest, sr.ReadToEnd());
                }
            }
            catch (AggregateException ex)
            {
                Logger.LogDebug($@"AGGREGATE EXCEPTION - {ex.InnerExceptions}");
                while (true)
                {
                    response = client.GetAsync(Source.config);
                    if (response.Result.IsSuccessStatusCode)
                        break;
                    Task.Delay(5000);
                }
                statusDic.Add(response.Result.StatusCode, response.Result.ToString());
            }
            return statusDic;
