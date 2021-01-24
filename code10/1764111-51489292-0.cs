    // registration
    builder.RegisterType<SqlConnection>()
        .As<IDbConnection>()
        .WithParameter(new NamedParameter("connectionString", WebConfigUtils.DefaultConnectionString))
        .InstancePerLifetimeScope();
    // usage
    public class GetRolePermissions
    {
        public class Command: IRequest<List<string>>
        {
            public ICollection<AspNetUserRole> UserRoles { get; set; }
        }
        public class Handler : AsyncRequestHandler<Command, List<string>>
        {
            private Func<Owned<IDbConnection>> _connectionFactory;
            public Handler(Func<Owned<IDbConnection>> connectionFactory)
            {
                _connectionFactory = connectionFactory;
            }
            
            // not really sure where your consuming code is, so just something off the top of my head
            public DontKnowYourResultType Handle(GetRolePermissions.Command cmd) {
                using (var ownedConnection = _connectionFactory()) {
                    // ownedConnection.Value is the DbConnection you want
                    // ... do your stuff with that connection
                } // and connection gets destroyed upon leaving "using" scope
            }
        }
    }
