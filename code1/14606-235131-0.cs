    public class SessionProxy
    {
        private HttpSessionState session; // use dependency injection for testability
        public SessionProxy( HttpSessionState session )
        {
           this.session = session;  //might need to throw an exception here if session is null
        }
    
        public DateTime LastUpdate
        {
           get { return this.session["LastUpdate"] != null
                             ? (DateTime)this.session["LastUpdate"] 
                             : DateTime.MinValue; }
           set { this.session["LastUpdate"] = value; }
        }
        public string UserLastName
        {
           get { return (string)this.session["UserLastName"]; }
           set { this.session["UserLastName"] = value; }
        }
    }
