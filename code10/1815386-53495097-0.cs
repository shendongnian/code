     public override void Up()
        {
            CreateTable(
                "dbo.ExampleTable",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"),               
                    RowGuid = c.Guid(nullable: false, defaultValueSql: "newid()"),
                   
                })
                .PrimaryKey(t => t.Id);           
        }
