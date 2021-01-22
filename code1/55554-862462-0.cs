    class Session
    {
        public bool   Exists;
        public string ID;
    }
    Session GetUserSession(int userID) {...}
    ...
    Session session = GetUserSessionID(1);
     
    if (session.Exists)
    {
        ... use session.ID
    }
