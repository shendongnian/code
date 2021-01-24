    public override void Up()
    {
        DropForeignKey("dbo.DriverWork", "DriverId", "dbo.Driver");
        DropForeignKey("dbo.DriverWork", "WorkPageId", "dbo.WorkPages");
        DropIndex("dbo.DriverWork", new[] { "DriverId" });
        DropIndex("dbo.DriverWork", new[] { "WorkPageId" });
        AlterColumn("dbo.DriverWork", "WorkPageId", c => c.Int(nullable: false));
        CreateIndex("dbo.DriverWork", "WorkPageId");
        AddForeignKey("dbo.DriverWork", "WorkPageId", "dbo.WorkPage", "Id", cascadeDelete: true);
        DropColumn("dbo.DriverWork", "DriverId");
    }
