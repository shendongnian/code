                    /// <summary>
                    /// An expanded web client that allows certificate auth and 
                    /// the retrieval of status' for successful requests
                    /// </summary>
                    public class WebClientCert : WebClient
                    {
                        private X509Certificate2 _cert;
                        public WebClientCert(X509Certificate2 cert) : base() { _cert = cert; }
                        protected override WebRequest GetWebRequest(Uri address)
                        {
                            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                            if (_cert != null) { request.ClientCertificates.Add(_cert); }
                            return request;
                        }
                        protected override WebResponse GetWebResponse(WebRequest request)
                        {
                            WebResponse response = null;
                            response = base.GetWebResponse(request);
                            HttpWebResponse baseResponse = response as HttpWebResponse;
                            StatusCode = baseResponse.StatusCode;
                            StatusDescription = baseResponse.StatusDescription;
                            return response;
                        }
                        /// <summary>
                        /// The most recent response statusCode
                        /// </summary>
                        public HttpStatusCode StatusCode { get; set; }
                        /// <summary>
                        /// The most recent response statusDescription
                        /// </summary>
                        public string StatusDescription { get; set; }
                    }
