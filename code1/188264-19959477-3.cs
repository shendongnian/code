    class WebClientEx : WebClient
    {
        private WebResponse m_Resp = null;
        protected override WebResponse GetWebResponse(WebRequest Req, IAsyncResult ar)
        {
            try
            {
                this.m_Resp = base.GetWebResponse(request);
            }
            catch (WebException ex)
            {
                if (this.m_Resp == null)
                    this.m_Resp = ex.Response;
            }
            return this.m_Resp;
        }
        public HttpStatusCode StatusCode
        {
            get
            {
                if (m_Resp != null && m_Resp is HttpWebResponse)
                    return (m_Resp as HttpWebResponse).StatusCode;
                else
                    return HttpStatusCode.OK;
            }
        }
    }
