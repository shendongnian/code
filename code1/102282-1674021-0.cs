    public class UserIp
    {
        private string _StrIpAddress;
        /// <summary>
        /// Initializes a new instance of the UserIp class.
        /// </summary>
        public UserIp()
        {            
            _StrIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (_StrIpAddress == null)
                _StrIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
