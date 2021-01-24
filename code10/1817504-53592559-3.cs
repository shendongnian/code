    /// <summary>
    /// A <see cref="MigrationOperation"/> for creating a new user-defined table type
    /// </summary>
    public class CreateUserDefinedTableTypeOperation : MigrationOperation
    {
        /// <summary>
        ///     The name of the user defined table type.
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        ///     The schema that contains the user defined table type, or <c>null</c> if the default schema should be used.
        /// </summary>
        public virtual string Schema { get; set; }
        /// <summary>
        ///     An ordered list of <see cref="AddColumnOperation" /> for adding columns to the user defined list.
        /// </summary>
        public virtual List<AddColumnOperation> Columns { get; } = new List<AddColumnOperation>();
    }
    /// <summary>
    /// A <see cref="MigrationOperation"/> for dropping an existing user-defined table type
    /// </summary>
    public class DropUserDefinedTableTypeOperation : MigrationOperation
    {
        /// <summary>
        ///     The name of the user defined table type.
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        ///     The schema that contains the user defined table type, or <c>null</c> if the default schema should be used.
        /// </summary>
        public virtual string Schema { get; set; }
    }
    /// <summary>
    ///     A builder for <see cref="CreateUserDefinedTableTypeOperation" /> operations.
    /// </summary>
    /// <typeparam name="TColumns"> Type of a typically anonymous type for building columns. </typeparam>
    public class UserDefinedTableTypeColumnsBuilder
    {
        private readonly CreateUserDefinedTableTypeOperation _createTableOperation;
        /// <summary>
        ///     Constructs a builder for the given <see cref="CreateUserDefinedTableTypeOperation" />.
        /// </summary>
        /// <param name="createUserDefinedTableTypeOperation"> The operation. </param>
        public UserDefinedTableTypeColumnsBuilder(CreateUserDefinedTableTypeOperation createUserDefinedTableTypeOperation)
        {
            _createTableOperation = createUserDefinedTableTypeOperation ??
                throw new ArgumentNullException(nameof(createUserDefinedTableTypeOperation));
        }
        public virtual OperationBuilder<AddColumnOperation> Column<T>(
            string type = null,
            bool? unicode = null,
            int? maxLength = null,
            bool rowVersion = false,
            string name = null,
            bool nullable = false,
            object defaultValue = null,
            string defaultValueSql = null,
            string computedColumnSql = null,
            bool? fixedLength = null)
        {
            var operation = new AddColumnOperation
            {
                Schema = _createTableOperation.Schema,
                Table = _createTableOperation.Name,
                Name = name,
                ClrType = typeof(T),
                ColumnType = type,
                IsUnicode = unicode,
                MaxLength = maxLength,
                IsRowVersion = rowVersion,
                IsNullable = nullable,
                DefaultValue = defaultValue,
                DefaultValueSql = defaultValueSql,
                ComputedColumnSql = computedColumnSql,
                IsFixedLength = fixedLength
            };
            _createTableOperation.Columns.Add(operation);
            return new OperationBuilder<AddColumnOperation>(operation);
        }
    }
    /// <summary>
    /// An extended version of the default <see cref="SqlServerMigrationsSqlGenerator"/> 
    /// which adds functionality for creating and dropping User-Defined Table Types of SQL 
    /// server inside migration files using the same syntax as creating and dropping tables, 
    /// to use this generator, register it using <see cref="DbContextOptionsBuilder.ReplaceService{ISqlMigr, TImplementation}"/>
    /// in order to replace the default implementation of <see cref="IMigrationsSqlGenerator"/>
    /// </summary>
    public class CustomSqlServerMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public CustomSqlServerMigrationsSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
            IMigrationsAnnotationProvider migrationsAnnotations) : base(dependencies, migrationsAnnotations)
        {
        }
        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            if (operation is CreateUserDefinedTableTypeOperation createUdtOperation)
            {
                GenerateCreateUdt(createUdtOperation, model, builder);
            }
            else if(operation is DropUserDefinedTableTypeOperation dropUdtOperation)
            {
                GenerateDropUdt(dropUdtOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }
        private void GenerateCreateUdt(
            CreateUserDefinedTableTypeOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            builder
                .Append("CREATE TYPE ")
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema))
                .AppendLine(" AS TABLE (");
            using (builder.Indent())
            {
                for (var i = 0; i < operation.Columns.Count; i++)
                {
                    var column = operation.Columns[i];
                    ColumnDefinition(column, model, builder);
                    if (i != operation.Columns.Count - 1)
                    {
                        builder.AppendLine(",");
                    }
                }
                builder.AppendLine();
            }
            builder.Append(")");
            builder.AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator).EndCommand();
        }
        private void GenerateDropUdt(
            DropUserDefinedTableTypeOperation operation,
            MigrationCommandListBuilder builder)
        {
            builder
                .Append("DROP TYPE ")
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema))
                .AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator)
                .EndCommand();
        }
    }
    public static class MigrationBuilderExtensions
    {
        /// <summary>
        ///     Builds an <see cref="CreateUserDefinedTableTypeOperation" /> to create a new user-defined table type.
        /// </summary>
        /// <typeparam name="TColumns"> Type of a typically anonymous type for building columns. </typeparam>
        /// <param name="name"> The name of the user-defined table type. </param>
        /// <param name="columns">
        ///     A delegate using a <see cref="ColumnsBuilder" /> to create an anonymous type configuring the columns of the user-defined table type.
        /// </param>
        /// <param name="schema"> The schema that contains the user-defined table type, or <c>null</c> to use the default schema. </param>
        /// <returns> A builder to allow annotations to be added to the operation. </returns>
        public static MigrationBuilder CreateUserDefinedTableType<TColumns>(
            this MigrationBuilder builder,
            string name,
            Func<UserDefinedTableTypeColumnsBuilder, TColumns> columns,
            string schema = null)
        {
            var createUdtOperation = new CreateUserDefinedTableTypeOperation
            {
                Name = name,
                Schema = schema
            };
            var columnBuilder = new UserDefinedTableTypeColumnsBuilder(createUdtOperation);
            var columnsObject = columns(columnBuilder);
            var columnMap = new Dictionary<PropertyInfo, AddColumnOperation>();
            foreach (var property in typeof(TColumns).GetTypeInfo().DeclaredProperties)
            {
                var addColumnOperation = ((IInfrastructure<AddColumnOperation>)property.GetMethod.Invoke(columnsObject, null)).Instance;
                if (addColumnOperation.Name == null)
                {
                    addColumnOperation.Name = property.Name;
                }
                columnMap.Add(property, addColumnOperation);
            }
            builder.Operations.Add(createUdtOperation);
            return builder;
        }
        /// <summary>
        ///     Builds an <see cref="DropUserDefinedTableTypeOperation" /> to drop an existing user-defined table type.
        /// </summary>
        /// <param name="name"> The name of the user-defined table type to drop. </param>
        /// <param name="schema"> The schema that contains the user-defined table type, or <c>null</c> to use the default schema. </param>
        /// <returns> A builder to allow annotations to be added to the operation. </returns>
        public static MigrationBuilder DropUserDefinedTableType(
            this MigrationBuilder builder,
            string name,
            string schema = null)
        {
            builder.Operations.Add(new DropUserDefinedTableTypeOperation
            {
                Name = name,
                Schema = schema
            });
            return builder;
        }
    }
