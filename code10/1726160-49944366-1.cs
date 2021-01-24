    public class User
    {
        public string UserName { get; set; }
        [Key]
        public string ApiKey { get; set; }  //unique database key and API key for user
        [InverseProperty("User")]
        public virtual ICollection<Log> Logs { get; set; }
        public User() { }
    }
    public class Log
    {
        [Key] 
        public int logID { get; set; }
        public string logString { get; set; }
        public string logDateTime { get; set; }
        public string userAPIKey { get; set; }
        [ForeignKey("userAPIKey")
        public virtual User User {get; set; }
        public Log() { }
    }
