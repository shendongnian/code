    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageDataSectionOrigin",
                table: "Translations",
                nullable: true);
            migrationBuilder.Sql(@"
                INSERT INTO Translations (TranslateRU, PageDataSectionOrigin)
                SELECT DataText, PageDataSectionId FROM PageDataSections
            ");
        }
    }
