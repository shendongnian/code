    public class HttpWebConnection
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern bool InternetSetCookie(
            string url,
            string name,
            string cookieData);
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern bool InternetGetCookie(
            string url,
            string name,
            StringBuilder cookieData,
            ref int length);
        public HttpWebConnection()
        {
            Cookies = new CookieContainer();
            AutoRedirect = false;
        }
        public HttpWebConnection(string baseAddress)
            : this()
        {
            BaseAddress = baseAddress;
            BaseUri = new Uri(BaseAddress);
        }
        public bool AutoRedirect { get; set; }
        public Uri BaseUri { get; private set; }
        public string BaseAddress { get; private set; }
        public CookieContainer Cookies { get; private set; }
        public virtual HttpWebResponse Send(string method, Uri uri)
        {
            return Send(method, uri, null, false);
        }
        public virtual HttpWebResponse Send(string method, Uri uri, string post, bool authenticating)
        {
            Uri absoluteUri = null;
            if (uri.IsAbsoluteUri)
            {
                absoluteUri = uri;
            }
            else
            {
                absoluteUri = new Uri(BaseUri, uri);
            }
            HttpWebRequest request = WebRequest.Create(absoluteUri) as HttpWebRequest;
            request.CookieContainer = Cookies;
            request.Method = method;
            if (method == "POST")
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            request.AllowAutoRedirect = false;
            if (!string.IsNullOrEmpty(post))
            {
                Stream requestStream = request.GetRequestStream();
                byte[] buffer = Encoding.UTF8.GetBytes(post);
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Close();
            }
            HttpWebResponse response = null;
            response = request.GetResponse() as HttpWebResponse;
            foreach (Cookie cookie in response.Cookies)
            {
                bool result = InternetSetCookie(BaseAddress, cookie.Name, cookie.Value);
                if (!result)
                {
                    int errorNumber = Marshal.GetLastWin32Error();
                }
            }
            if (AutoRedirect && (response.StatusCode == HttpStatusCode.SeeOther
                        || response.StatusCode == HttpStatusCode.RedirectMethod
                        || response.StatusCode == HttpStatusCode.RedirectKeepVerb
                        || response.StatusCode == HttpStatusCode.Redirect
                        || response.StatusCode == HttpStatusCode.Moved
                        || response.StatusCode == HttpStatusCode.MovedPermanently))
            {
                string uriString = response.Headers[HttpResponseHeader.Location];
                Uri locationUri;
                //TODO investigate if there is a better way to detect for a relative vs. absolute uri.
                if (uriString.StartsWith("HTTP", StringComparison.OrdinalIgnoreCase))
                {
                    locationUri = new Uri(uriString);
                }
                else
                {
                    locationUri = new Uri(this.BaseUri, new Uri(uriString));
                }
                response = Send("GET", locationUri);
            }
            
            return response;
        }
    }
