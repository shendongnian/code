    class ViewModel
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public ViewModel()
        {
            LogInCommand = new Command(OnLogIn);
        }
        private void OnLogIn()
        {
            // your login logic shall go here
            // your password and user name shall be bound 
            // via other properties
            // Invoke the LoggedIn event with the user name 
            // of the logged in user.
            LoggedIn?.Invoke(userName);
        }
        public event Action<string> LoggedIn;
        public Command LogInCommand { get; }
    }
