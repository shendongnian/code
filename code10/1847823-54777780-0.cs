    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public override void Configure(Container container)
    {
        SetConfig(new HostConfig {
            DefaultRedirectPath = "/metadata",
            DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
        });
        container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(
            "Server=localhost;Database=test;UID=root;Password=test;SslMode=none",
            MySqlDialect.Provider));
        using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
        {
            db.DropAndCreateTable<Person>();
            db.Insert(new Person {Id = 1, Name = "Name"});
            var s = db.Select<Person>().Dump();
            s.PrintDump();
        }
        var model = ModelDefinition<Person>.Definition;
        model.Name.Print();
    }
