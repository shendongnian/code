    public class CurrentSession : MySession<PublicUser>
    {
        public static CurrentSession Instance = new CurrentSession();
    
        protected override PublicUser LoadCurrentUser(string username)
        {
            // This would be a data logic call to load a user's detail from the database
            return new PublicUser(username);
        }
    
        // Put additional session objects here
        public const string SESSIONOBJECT1 = "CurrentObject1";
        public const string SESSIONOBJECT2 = "CurrentObject2";
    
        public Object1 CurrentObject1
        {
            get
            {
                if (Session[SESSIONOBJECT1] == null)
                    Session[SESSIONOBJECT1] = new Object1();
    
                return Session[SESSIONOBJECT1] as Object1;
            }
            set
            {
                Session[SESSIONOBJECT1] = value;
            }
        }
    
        public Object2 CurrentObject2
        {
            get
            {
                if (Session[SESSIONOBJECT2] == null)
                    Session[SESSIONOBJECT2] = new Object2();
    
                return Session[SESSIONOBJECT2] as Object2;
            }
            set
            {
                Session[SESSIONOBJECT2] = value;
            }
        }
    }
