    migrationBuilder.CreateTable(
                name: "HMTUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    HHID = table.Column<int>(nullable: false),
                    HMTHID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HMTUsers", x => new { x.HHID, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_HMTUsers_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HMTUsers_HTMs_HMTHID",
                        column: x => x.HMTHID,
                        principalTable: "HTMs",
                        principalColumn: "HID",
                        onDelete: ReferentialAction.Restrict);
                });
