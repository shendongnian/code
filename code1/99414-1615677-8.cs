    public class MyService 
    {
        // keeners will realise this too should be injected
        // as a dependency, but just cut and pasted to demonstrate
        // isolation
        private AuthenticationService _auth = new AuthenticationService ();
        private int _count = 0;
        public string DoSomething ()
        {
            if (_auth.Authenticate ())
            {
                _count++;
            }
            return count.ToString ();
        }
    }
