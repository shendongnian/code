    private class BetterWebClient : WebClient
        {
            private WebRequest _Request;
            protected override WebRequest GetWebRequest(Uri address)
            {
                this._Request = base.GetWebRequest(address);
                
                if (this._Request is HttpWebRequest)
                {
                    ((HttpWebRequest)this._Request).AllowAutoRedirect = false;
                }
                return this._Request;
            } 
            public HttpStatusCode StatusCode()
            {
                HttpStatusCode result;
                HttpWebResponse response = base.GetWebResponse(this._Request) as HttpWebResponse;
                if (response != null)
                {
                    result = response.StatusCode;
                }
                else
                {
                    throw (new InvalidOperationException("Unable to retrieve the status code, maybe you haven't made a request yet."));
                }
                return result;
            }
        }
