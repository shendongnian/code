    public class UserInfo
    {
        private HttpSessionStateWrapper _session;
        public UserInfo(HttpSessionStateWrapper session)
        ( 
           // throw if null etc
           _session = session;
        )
            
        public Decimal Latitude
        {
            get { return _session["Latitude"]; }
            set { _latitude = _session["Latitude"] = value; }
        }
    }
