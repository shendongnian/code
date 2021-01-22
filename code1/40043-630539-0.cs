    public class Authenticator
    {
        public event EventHandler AuthenticationFailed = delegate { };
        protected virtual void OnAuthenticationFailed()
        {
            AuthenticationFailed(this, EventArgs.Empty);
        }
    }
