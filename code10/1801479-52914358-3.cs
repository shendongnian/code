    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataText",
                table: "PageDataSections");
            migrationBuilder.AddColumn<int>(
                name: "DataTextTranslationId",
                table: "PageDataSections",
                nullable: true);
            migrationBuilder.Sql(@"
                UPDATE PageDataSections SET DataTextTranslationId = (select TranslationId FROM Translations WHERE PageDataSectionOrigin=PageDataSectionId)
            ");
            migrationBuilder.DropColumn(
                name: "PageDataSectionOrigin",
                table: "Translations");
        }
    }
