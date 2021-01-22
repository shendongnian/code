        public static string GetConnectionString() {
            using (var session = ActiveRecordMediator
                                .GetSessionFactoryHolder()
                                .GetSessionFactory(typeof(ActiveRecordBase))
                                .OpenSession())
            {
                return session.Connection.ConnectionString;
            }
        }
