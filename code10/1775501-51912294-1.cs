    [DbContext(typeof(MyDbContext))]
    [Migration("MyCustomMigration")]
    public class FooMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script = "<some long script>";
            migrationBuilder.Sql(script);
        }
    }
