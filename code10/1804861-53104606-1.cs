     public class AuthService
    {
        private FirebaseAuth firebaseAuth;
        
        public AuthService()
        {
           Initialise();
        }
        private void Initialise()
        {
            this.firebaseAuth = FirebaseAuth.Instance;
        }    
        public void SignInWithEmailAndPassword(string email, string password, AuthListener authListener)
        {
            FirebaseAuth.Instance.SignInWithEmailAndPassword(email, password)
                .AddOnSuccessListener(authListener)
                .AddOnFailureListener(authListener);
        }
        public void CreateUserWithEmailAndPassword(string email, string password, string userName, AuthListener authListener)
        {
            FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password)
                .AddOnFailureListener(authListener)
                .AddOnSuccessListener(authListener);
        }
        public void SignOut()
        {
            FirebaseAuth.Instance.SignOut();
        }
    }
