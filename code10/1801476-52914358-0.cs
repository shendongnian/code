    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TranslateEN = table.Column<string>(nullable: true),
                    TranslateRU = table.Column<string>(nullable: true),
                    TranslateUA = table.Column<string>(nullable: true),
                    PageDataSectionOrigin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationId);
                });
            migrationBuilder.Sql(@"
                INSERT INTO Translations (TranslateRU, PageDataSectionOrigin)
                SELECT DataText, PageDataSectionId FROM PageDataSections
            ");
        }
    }
