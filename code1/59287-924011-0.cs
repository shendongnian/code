    return Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.UsingFile("c:\\blog.db"))
                    .Mappings(x => x.AutoMappings.Add(
                       AutoPersistenceModel.MapEntitiesFromAssemblyOf<Blog>()
                           .WithSetup(a => a.IsBaseType = type => type == typeof(DomainEntity))
                           .Where(type =>
                               type.Namespace.EndsWith("Domain.Model") &&
                               !type.IsAbstract &&
                               type.IsClass &&
                               type.GetProperty("Id") != null)
                       )).BuildSessionFactory();
