    public class Packet
    {
        private Dictionary<string, string> _dictionary =
            new Dictionary<string, string>();
        public string this[string key]
        {
            get
            {
                if (_dictionary.ContainsKey(key))
                {
                    return _dictionary[key];
                }
                else { return ""; }
            }
            set { _dictionary[key] = value; }
        }
    }
    public class LoginPacket : Packet
    {
        public string Username
        {
            get { return this["Username"]; }
            set { this["Username"] = value; }
        }
        public string Password
        {
            get { return this["Password"]; }
            set { this["Password"] = value; }
        }
        public int Status
        {
            get { return int.Parse(this["Status"]); }
            set { this["Status"] = value.ToString(); }
        }
    }
