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
    }
