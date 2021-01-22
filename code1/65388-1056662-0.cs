    namespace TestLinq2Sql.Shared
    {
        public class SharedContext : DataContext
        {
            public Table<User> Users;
            public SharedContext (string connectionString) : base(connectionString) { }
        }
        [Table(Name = "Users")]
        public class User
        {
            [Column(DbType = "Int NOT NULL IDENTITY", IsPrimaryKey=true, CanBeNull = false)]
            public int Id { get; set; }
            [Column(DbType = "nvarchar(40)", CanBeNull = false)]
            public string Name { get; set; }
            [Column(DbType = "nvarchar(100)", CanBeNull = false)]
            public string Email { get; set; }
        }
    }
