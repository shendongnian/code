    public class FixedMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
    {
        public FixedMySqlMigrationSqlGenerator()
            :base()
        {
        }
        /// <summary>
        /// we want BTREE because HASH is not correct for normal Keys on MySQL 8
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        protected override MigrationStatement Generate(CreateIndexOperation op)
        {
            MigrationStatement migrationStatement = base.Generate(op);
            System.Diagnostics.Trace.WriteLine(migrationStatement.Sql);
            string fubarSql = migrationStatement.Sql.TrimEnd();
            if(fubarSql.EndsWith("using HASH",StringComparison.OrdinalIgnoreCase))
            {
                string modSql = fubarSql.Replace("using HASH", " using BTREE");
                migrationStatement.Sql = modSql;
            }
            return migrationStatement;
        }
    }
