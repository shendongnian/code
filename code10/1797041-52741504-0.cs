    public class SomeClassThatNeedsAuth
    {
        public SomeClassThatNeedsAuth(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }
    
        private readonly IAuthProvider _authProvider;
    }
