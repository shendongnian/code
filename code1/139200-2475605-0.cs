    public class TimeoutWebClient : WebClient
    {
        private int _timeOut = 10000;
        public int TimeOut
        {
            get
            {
                return _timeOut;
            }
            set
            {
                _timeOut = value;
            }
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            webRequest.Timeout = _timeOut;
            return webRequest;
        }
    }
