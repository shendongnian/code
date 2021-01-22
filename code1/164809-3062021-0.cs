    public class User
    {
        public virtual int Id { get; set; }
        public virtual UserClass ValueA { get; set; }
        public virtual UserClass ValueB { get; set; }
        public virtual UserClass UserClass { get { return ValueB ?? ValueA; } }
    }
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("MyUserTable");
            Id(user => user.Id).GeneratedBy.Identity();
            References(user => user.ValueA).Not.Nullable();
            References(user => user.ValueB).Nullable();
        }
    }
