    // part of a default abstract setup class I use
    public ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
            .Database(
                MsSqlConfiguration.MsSql2008
                    .ConnectionString(c =>
                        c.Server(this.ServerName)
                        .Database(this.DatabaseName)
                        .Username(this.Username)
                        .Password(this.Password)
                        )
            )
            .Mappings(m =>
                m.AutoMappings.Add(AutoMap.AssemblyOf<User>()   // loads all POCOse
                    .Where(t => t.Namespace == this.Namespace))
                    // here go the associations and constraints,
                    // (or you can annotate them, or add them later)
                )
            .ExposeConfiguration(CreateOrUpdateSchema)
            .BuildSessionFactory();
    }
    // example of an entity
    // this example is deliberately made slightly easier, lookup the Fluent docs
    // it has very simple and easy-to-follow instructions how to set this up
    // but this illustrates the main general idea
    public class User
    {
        public virtual int Id { get; private set; }   // autogens PK
        public virtual string Name { get; set; }      // augogens Name col
        public virtual byte[] Picture { get; set; }   // autogens Picture BLOB col
        public virtual List<UserSettings> Settings { get; set; }  // autogens to many-to-one
    }
    
    public class UserSettings
    {
        public virtual int Id { get; private set: }   // PK again
        public virtual int UserId { get; set; }       // FK
        public virtual User { get; set; }             // OO-mapping to User table
    }
