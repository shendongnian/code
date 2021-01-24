    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppliedOnUtc",
                schema: "Conversations",
                table: "__MigrationsHistory",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                type: "datetime2");
        }
         ....
    }
