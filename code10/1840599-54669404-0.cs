    public class SessionPolicy : DefaultPooledObjectPolicy<Session>
    {
        public override Session Create()
        {
            //Do whatever is needed here
            return session;
        }
    }
