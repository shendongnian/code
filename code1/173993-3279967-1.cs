    private static string doRequestWithBytesPostData(string requestUri, string method, byte[] postData,
                                            CookieContainer cookieContainer,
                                            string userAgent, string acceptHeaderString,
                                            string referer,
                                            string contentType, out string responseUri)
            {
                var result = "";
                if (!string.IsNullOrEmpty(requestUri))
                {
                    var request = WebRequest.Create(requestUri) as HttpWebRequest;
                    if (request != null)
                    {
                        request.KeepAlive = true;
                        var cachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                        request.CachePolicy = cachePolicy;
                        request.Expect = null;
                        if (!string.IsNullOrEmpty(method))
                            request.Method = method;
                        if (!string.IsNullOrEmpty(acceptHeaderString))
                            request.Accept = acceptHeaderString;
                        if (!string.IsNullOrEmpty(referer))
                            request.Referer = referer;
                        if (!string.IsNullOrEmpty(contentType))
                            request.ContentType = contentType;
                        if (!string.IsNullOrEmpty(userAgent))
                            request.UserAgent = userAgent;
                        if (cookieContainer != null)
                            request.CookieContainer = cookieContainer;
    
                        request.Timeout = Constants.RequestTimeOut;
    
                        if (request.Method == "POST")
                        {
                            if (postData != null)
                            {
                                request.ContentLength = postData.Length;
                                using (var dataStream = request.GetRequestStream())
                                {
                                    dataStream.Write(postData, 0, postData.Length);
                                }
                            }
                        }
    
                        using (var httpWebResponse = request.GetResponse() as HttpWebResponse)
                        {
                            if (httpWebResponse != null)
                            {
                                responseUri = httpWebResponse.ResponseUri.AbsoluteUri;
                                cookieContainer.Add(httpWebResponse.Cookies);
                                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                                {
                                    result = streamReader.ReadToEnd();
                                }
                                return result;
                            }
                        }
                    }
                }
                responseUri = null;
                return null;
            }
