    static DbContextOptions GetOptions(IModel model)
    {
        var builder = new DbContextOptionsBuilder();
        builder
            .UseSqlServer(connStr)
            .UseModel(model);
        return builder.Options;
    }
    
    //Test 1
    class Test1EntityA
    {
        public int Id { get; set; }
        public string StrProp { get; set; }
    }
    
    //Test 2
    class Test2EntityA
    {
        public int Id { get; set; }
        public string StrProp { get; set; }
        public ICollection<Test2ModelBEntity> Children { get; set; }
    }
    class Test2EntityB
    {
        public int Id { get; set; }
        public int EntityAId { get; set; }
        public Test2EntityA EntityA { get; set; }
    }
    
    static void Main(string[] args)
    {
        var emptyModelBuilder = new ModelBuilder(new ConventionSet());
        var emptyModel = emptyModelBuilder.Model;
        using (var baseCtx = new TestContext(GetOptions(emptyModel)))
        {
            //Get all services we need from the base context
            var conventions = ConventionSet.CreateConventionSet(baseCtx);
            var migrationServices = new ServiceCollection()
                .AddDbContextDesignTimeServices(baseCtx)
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();
            //Test 1
            var test1ModelBuilder = new ModelBuilder(conventions);
            test1ModelBuilder.Entity<Test1EntityA>()
                .ToTable("EntityA");
            var test1Model = test1ModelBuilder.GetInfrastructure().Metadata;
            test1Model.Validate();
            var operations = migrationServices.GetRequiredService<IMigrationsModelDiffer>().GetDifferences(emptyModel, test1Model);
            var commands = migrationServices.GetRequiredService<IMigrationsSqlGenerator>().Generate(operations, test1Model);
            var connection = migrationServices.GetRequiredService<IRelationalConnection>();
            migrationServices.GetRequiredService<IMigrationCommandExecutor>().ExecuteNonQuery(commands, connection);
            using (TestContext ctx = new TestContext(GetOptions(test1Model)))
            {
                ctx.Set<Test1EntityA>().Add(new Test1EntityA
                {
                    StrProp = "test1",
                });
                ctx.SaveChanges();
            }
            //Test 2
            var test2ModelBuilder = new ModelBuilder(conventions);
            test2ModelBuilder.Entity<Test2EntityA>()
                .ToTable("EntityA");
            test2ModelBuilder.Entity<Test2EntityB>()
                .ToTable("EntityB");
            var test2Model = test2ModelBuilder.GetInfrastructure().Metadata;
            test2Model.Validate();
            operations = migrationServices.GetRequiredService<IMigrationsModelDiffer>().GetDifferences(test1Model, test2Model);
            commands = migrationServices.GetRequiredService<IMigrationsSqlGenerator>().Generate(operations, test2Model);
            migrationServices.GetRequiredService<IMigrationCommandExecutor>().ExecuteNonQuery(commands, connection);
            using (TestContext ctx = new TestContext(GetOptions(test2Model)))
            {
                var e = new Test2EntityA
                {
                    StrProp = "test2",
                };
                ctx.Set<Test2EntityA>().Add(e);
                ctx.Set<Test2EntityB>().Add(new Test2EntityB
                {
                    EntityA = e,
                });
                ctx.SaveChanges();
                    
                Console.WriteLine(ctx.Set<Test2EntityB>().Where(b => b.EntityA.StrProp == "test2").Count());
            }
        }
    }
