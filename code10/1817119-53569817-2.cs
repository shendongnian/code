    migrationBuilder.CreateTable(
        name: "MilitaryUnits",
        columns: table => new
        {
            Guid = table.Column<Guid>(nullable: false),
            CreatedAtTime = table.Column<DateTime>(type: "datetime", nullable: false),
            UpdatedAtTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
            Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
            Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_MilitaryUnits", x => x.Guid);
            table.UniqueConstraint("AK_MilitaryUnits_Name", x => x.Name);
        });
