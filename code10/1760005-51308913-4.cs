    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;
    
    namespace EfCoreTest.Migrations
    {
        public partial class InitialCreate : Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "levels",
                    columns: table => new
                    {
                        LevelId = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        ParentLevelId = table.Column<int>(nullable: true),
                        Name = table.Column<string>(nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_levels", x => x.LevelId);
                        table.ForeignKey(
                            name: "FK_levels_levels_ParentLevelId",
                            column: x => x.ParentLevelId,
                            principalTable: "levels",
                            principalColumn: "LevelId",
                            onDelete: ReferentialAction.Restrict);
                    });
    
                migrationBuilder.CreateIndex(
                    name: "IX_levels_ParentLevelId",
                    table: "levels",
                    column: "ParentLevelId");
            }
    
            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "levels");
            }
        }
    }
