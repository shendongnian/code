    public class ReadUserInfo : UserInfo
    {
        internal ReadUserInfo()
        {
        }
        new public int ID { get; internal set; }
        new internal string Password { get; set; }
        new public string Username { get; internal set; }
    }
