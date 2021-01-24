    public class Repository
    {
        private string Username { get; set; }
        public void InjectUsername(string username)
        {
            Username = username;
        }
    }
