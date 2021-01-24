    public override void Up()
    {
        RenameColumn("Docks", "ProfileId", "SecondId");
    }
    public override void Down()
    {
        RenameColumn("Docks", "SecondId", "ProfileId");
    }
