     Database.SetInitializer(new CreateMySqlDatabaseIfNotExists<MyContext>());
     internal class CreateMySqlDatabaseIfNotExists<TContext>: IDatabaseInitializer<TContext> where TContext : MyContext
    {
        public void InitializeDatabase(TContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(false))
                    throw new InvalidOperationException("The model has changed!");
            }
            else
            {
                CreateMySqlDatabase(context);
                Seed(context);
            }
        }
        private void CreateMySqlDatabase(TContext context)
        {
            try
            {
                context.Database.Create();
                return;
            }
            catch (MySqlException ex)
            {
                // Ignore the parse exception
                if (ex.Number != 1064)
                {
                    throw;
                }
            }
            // Manually create the metadata table
            using (var connection = ((MySqlConnection) context
                                                           .Database.Connection).Clone())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"
                    CREATE TABLE __MigrationHistory (
                        MigrationId mediumtext NOT NULL,
                        CreatedOn datetime NOT NULL,
                        Model mediumblob NOT NULL,
                        ProductVersion mediumtext NOT NULL);
 
                    ALTER TABLE __MigrationHistory
                    ADD PRIMARY KEY (MigrationId(255));
 
                    INSERT INTO __MigrationHistory (
                        MigrationId,
                        CreatedOn,
                        Model,
                        ProductVersion)
                    VALUES (
                        'InitialCreate',
                        @CreatedOn,
                        @Model,
                        @ProductVersion);
                    ";
                command.Parameters.AddWithValue(
                    "@Model",
                    GetModel(context));
                command.Parameters.AddWithValue(
                    "@ProductVersion",
                    GetProductVersion());
                command.Parameters.AddWithValue(
                   "@CreatedOn",
                   DateTime.Now);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private byte[] GetModel(TContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(
                    memoryStream,
                    CompressionMode.Compress))
                using (var xmlWriter = XmlWriter.Create(
                    gzipStream,
                    new XmlWriterSettings {Indent = true}))
                {
                    EdmxWriter.WriteEdmx(context, xmlWriter);
                }
                return memoryStream.ToArray();
            }
        }
        private string GetProductVersion()
        {
            return typeof (DbContext).Assembly
                .GetCustomAttributes(false)
                .OfType<AssemblyInformationalVersionAttribute>()
                .Single()
                .InformationalVersion;
        }
        protected void Seed(TContext context)
        { // ...
            context.SaveChanges();
        }
    }
