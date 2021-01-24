    migrationBuilder.CreateTable(
                    name: "RssBlog",
                    columns: table => new
                    {
                        BlogId = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Url = table.Column<string>(nullable: true),
                        RssUrl = table.Column<string>(nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_RssBlog", x => x.BlogId);
                    });
