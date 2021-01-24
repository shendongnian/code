    public override void Up()
    {
        CreateTable(
            "dbo.WorkPage",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CommissionPercentage = c.Byte(nullable: false),
                    IsClosed = c.Boolean(nullable: false),
                    DateClosed = c.DateTime(),
                    DriverId = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Driver", t => t.DriverId, cascadeDelete: true)
            .Index(t => t.DriverId);
        
        AddColumn("dbo.DriverWork", "WorkPageId", c => c.Int());
        CreateIndex("dbo.DriverWork", "WorkPageId");
        AddForeignKey("dbo.DriverWork", "WorkPageId", "dbo.WorkPage", "Id");
        Sql(@"insert into dbo.WorkPage (CommissionPercentage, IsClosed, DateClosed, DriverId) select 0, 0, null, DriverId from dbo.DriverWork");
        Sql(@"update dbo.DriverWork set WorkPageId = WP.Id from dbo.DriverWork DW join dbo.WorkPage WP on DW.DriverId = WP.DriverId");
        DropForeignKey("dbo.DriverWork", "DriverId", "dbo.Driver");
        DropForeignKey("dbo.DriverWork", "WorkPageId", "dbo.WorkPages");
        DropIndex("dbo.DriverWork", new[] { "DriverId" });
        DropIndex("dbo.DriverWork", new[] { "WorkPageId" });
        AlterColumn("dbo.DriverWork", "WorkPageId", c => c.Int(nullable: false));
        CreateIndex("dbo.DriverWork", "WorkPageId");
        AddForeignKey("dbo.DriverWork", "WorkPageId", "dbo.WorkPage", "Id", cascadeDelete: true);
        DropColumn("dbo.DriverWork", "DriverId");
    }
