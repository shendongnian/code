    class WebClientEx : WebClient
    {
        private WebResponse m_Resp = null;
        protected override WebResponse GetWebResponse(WebRequest Req, IAsyncResult ar)
        {
            return m_Resp = base.GetWebResponse(Req, ar);
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
