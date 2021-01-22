    public abstract class Packet
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
        public abstract PacketType Type { get; }
    }
    public class LoginPacket : Packet
    {
        public override PacketType Type
        { get { return PacketType.Action; } }
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
        public int Status // Example: Not an actual key in Login in the Asterisk API
        {
            get { return int.Parse(this["Status"]); }
            set { this["Status"] = value.ToString(); }
        }
    }
