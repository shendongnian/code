    using System.Web.Script.Serialization;
    public class User
    {
        [ScriptIgnore]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
