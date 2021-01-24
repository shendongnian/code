     public override void Up()
    {
        RenameTable("dbo.Ciudads", "Ciudades");
    }
    public override void Down()
    {
        RenameTable("dbo.Ciudades", "Ciudads");
    }
