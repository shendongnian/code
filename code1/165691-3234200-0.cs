    class DbAccessProvider : Provider<Access>
        {
            public Access DbAccess { get; set; }
            protected override Access CreateInstance(IContext context)
            {
                return DbAccess;
            }
        }
    
    class TestModule : NinjectModule
        {
            public DbAccessProvider DbAccessProvider { get; set; }
            public override void Load()
            {
                Bind<Access>().ToProvider(DbAccessProvider);
            }
        }
