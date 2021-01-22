    return Fluently.Configure()
                    .Database(
                        IfxOdbcConfiguration
                            .Informix1000
                            .ConnectionString("Provider=Ifxoledbc.2;Password=password;Persist Security Info=True;User ID=username;Data Source=database@server")
                            .Dialect<InformixDialect1000>()
                            .ProxyFactoryFactory<ProxyFactoryFactory>()
                            .Driver<OleDbDriver>()
                            .ShowSql()
                        )
                    .Mappings(m => m.AutoMappings.Add(persistenceModel))
                    .BuildSessionFactory();
