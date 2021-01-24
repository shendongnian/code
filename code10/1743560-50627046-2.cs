    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedOnUtc",
                schema: "Conversations",
                table: "__MigrationsHistory",                
                defaultValueSql: "GETUTCDATE()"
            );
        }
         ....
    }
