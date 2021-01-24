        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Mytable",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                // Add for SQLite
                .Annotation("Sqlite:Autoincrement", true)
                // Add for MySQL
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                // Add for MSSQL
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                // Add for PostgreSQL
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                // Or other provider...
                Name = table.Column<string>(maxLength: 50, nullable: false),
                Text = table.Column<string>(maxLength: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Mytable", x => x.Id);
            });
        }
