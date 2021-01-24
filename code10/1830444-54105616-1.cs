    public override void Up()
    {
        CreateTable(
            "dbo.Students",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
            .PrimaryKey(t => t.Id);
        Sql("DBCC CHECKIDENT ('dbo.Students', RESEED, 100);");
    }
    
    public override void Down()
    {
        DropTable("dbo.Students");
    }
