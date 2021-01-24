        public object DownloadFromApi(string url)
        {
            if (WebRequest.Create(url) is HttpWebRequest request)
            {
                request.Method = "GET";
                request.ContentType = "application/json";
                try
                {
                    using (Stream response = request.GetResponse().GetResponseStream())
                        if (response != null)
                            using (var reader = new StreamReader(response))
                                return JsonConvert.DeserializeObject(reader.ReadToEnd());
                }
                catch (HttpRequestException exception)
                {
                    ApplicationProvider.Log.Error($"An unhandled HTTP error has occurred.{Environment.NewLine}{exception.Message}");
                    throw new Exception(exception.Message);
                }
            }
            ApplicationProvider.Log.Error($"Web request failed due to null value. {url}");
            throw new Exception($"A null parameter or response has occurred for {url}");
        }
