    public override void Up()
    {
        AddColumn("dbo.MyTable", "DateSortBy", c => c.DateTimeOffset(nullable: false, precision: 7));
        Sql("UPDATE dbo.MyTable SET DateSortBy = DateCreated");
    }
