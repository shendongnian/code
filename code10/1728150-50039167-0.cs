    public override void Up()
    {
        DropPrimaryKey("dbo.CustomerContracts");
        DropColumn("dbo.CustomerContracts", "TeamId"); // Drop this first
        AddColumn("dbo.CustomerContracts", "ItemId", c => c.Int(nullable: false, identity: true));
        AddPrimaryKey("dbo.CustomerContracts", "ItemId");
    }
