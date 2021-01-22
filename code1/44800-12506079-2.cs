        /// <summary>
        /// Copies all headers and content (except the URL) from an incoming to an outgoing
        /// request.
        /// </summary>
        /// <param name="source">The request to copy from</param>
        /// <param name="destination">The request to copy to</param>
        public static void CopyTo(this HttpRequestBase source, HttpWebRequest destination)
        {
            destination.Method = source.HttpMethod;
            // Copy unrestricted headers (including cookies, if any)
            foreach (var headerKey in source.Headers.AllKeys)
            {
                switch (headerKey)
                {
                    case "Connection":
                    case "Content-Length":
                    case "Date":
                    case "Expect":
                    case "Host":
                    case "If-Modified-Since":
                    case "Range":
                    case "Transfer-Encoding":
                    case "Proxy-Connection":
                        // Let IIS handle these
                        break;
                    case "Accept":
                    case "Content-Type":
                    case "Referer":
                    case "User-Agent":
                        // Restricted - copied below
                        break;
                    default:
                        destination.Headers[headerKey] = source.Headers[headerKey];
                        break;
                }
            }
            // Copy restricted headers
            if (source.AcceptTypes.Any())
            {
                destination.Accept = string.Join(",", source.AcceptTypes);
            }
            destination.ContentType = source.ContentType;
            destination.Referer = source.UrlReferrer.AbsoluteUri;
            destination.UserAgent = source.UserAgent;
            // Copy content (if content body is allowed)
            if (source.HttpMethod != "GET"
                && source.HttpMethod != "HEAD")
            {
                var destinationStream = destination.GetRequestStream();
                source.InputStream.CopyTo(destinationStream);
                destinationStream.Close();
            }
        }
