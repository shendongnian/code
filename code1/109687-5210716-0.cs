    // Strongly-typed access to session data
    public class MySessionData
    {
        // Gets the username of the current logged in user if logged in, otherwise null.
        public string MyUsername
        {
            get { return Session["MyUsername"]; }
            set { Session["MyUsername"] = value; }
        }
    }
