    class MyMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public MyMigrationsSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
            IMigrationsAnnotationProvider migrationsAnnotations)
            : base(dependencies, migrationsAnnotations)
        {
        }
    
        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            if (operation is CreateSpatialIndexOperation createSpatialIndexOperation)
            {
                Generate(createSpatialIndexOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }
    
        private void Generate(
            CreateSpatialIndexOperation operation,
            MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));
    
            builder
                .Append("CREATE INDEX ")
                .Append(sqlHelper.DelimitIdentifier(operation.Name))
                ...
                .Append(stringMapping.GenerateSqlLiteral(...))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
