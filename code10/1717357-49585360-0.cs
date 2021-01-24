    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserLog> UserLogs { get; set; }
    }
    public class UserLog
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogAction { get; set; }
        public DateTime LogCreatedOn { get; set; }
        public string By { get; set; }
        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
