                sessionFactory = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard
                                .UsingFile(DbFile)
                                // Display generated SQL in Output window
                                .ShowSql()
                              )
                    .Mappings(m => m.AutoMappings.Add( GetAutoPersistenceModel() ))
                    .BuildSessionFactory()
                    ;
