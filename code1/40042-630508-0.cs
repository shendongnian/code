    public class Authenticator
    {
        public event EventHandler AuthenticationFailed = delegate { };
        public Authenticator(bool sendEmailOnFailure)
        {
             if (sendEmailOnFailure)
             {
                 // No need for the no-op delegate any more, so just replace it.
                 AuthenticationFailed = EmailSender;
             }
        }
    }
