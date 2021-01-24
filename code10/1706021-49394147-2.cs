    public override void Up()
    {
        // RenameColumn("Docks", "ProfileId", "SecondId"); // old answer
        RenameColumn("Docks", "ProfileId", "SecondId", anonymousArguments: new { columnType = "int" });
    }
    public override void Down()
    {
        // RenameColumn("Docks", "SecondId", "ProfileId"); // old answer
        RenameColumn("Docks", "SecondId", "ProfileId", anonymousArguments: new { columnType = "int" });
    }
