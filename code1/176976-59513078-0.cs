    public class PlayerAuthData 
    {
        public readonly string emailId, password, userName;
        private string hello;
        public PlayerAuthData(string emailId, string password, string userName)
        {
            this.emailId = emailId;
            this.password = password;
            this.userName = userName;
        }
        public string Hello 
        {
            get { return hello; }
            set { hello = value; }
        }
    }
    public class AuthManager
    {
        void Start()
        {
            PlayerAuthData pad = new PlayerAuthData("a@a.com", "123123", "Mr.A");
            pad.Hello = "Hi there";
            print(pad.Hello);
            print(pad.password);
            print(pad.emailId);
            print(pad.userName);
        }
    }
