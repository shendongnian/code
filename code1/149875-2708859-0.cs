    public class WindowEventArgs : EventArgs
    {
        private readonly string username;
        private readonly string password;
        public string Username { get; private set; }
        public string Password { get; private set; }
    
        public WindowEventArgs(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
