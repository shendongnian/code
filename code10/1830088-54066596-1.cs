    public class DataContext : DbContext
    {
         public virtual DbSet<UserDo> UserDos { get; set; }
    }
    public class UserDo 
    {
        [Key]
        public int UserId {get;set}
        public string Username {get;set}
    }
