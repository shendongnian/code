    public class SignInPage : Page<_>
    {
        [FindById("email")]
        public EmailInput<_> Email { get; set; }
    
        [FindById("password")]
        public PasswordInput<_> Password { get; set; }
    
        //...
    }
