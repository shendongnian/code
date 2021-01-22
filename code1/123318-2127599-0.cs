    [Table(Name="Role")]
    public class Role
    {
        private EntitySet<User> _Users = new EntitySet<User>();
    
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int RoleID { get; set; }
        [Column] public string Name { get; set; }
        [Association(Name = "FK_User_Role", Storage = "_Users", ThisKey = "RoleID", OtherKey = "RoleID")]
        public EntitySet<User> Users
        {
            get{ return this._Users; }
            set{ this._Users.Assign(value);}
            }
    }
