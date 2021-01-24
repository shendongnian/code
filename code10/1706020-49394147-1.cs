    public override void Up()
    {
        RenameColumn("Docks", "ProfileId", "SecondId", anonymousArguments: new { columnType = "int" });
    }
    public override void Down()
    {
        RenameColumn("Docks", "SecondId", "ProfileId", , anonymousArguments: new { columnType = "int" });
    }
