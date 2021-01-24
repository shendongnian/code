    CreateTable(
        "DMS.Files",
        c => new
            {
                Id = c.Guid(nullable: false),
                ...
            })
        .PrimaryKey(t => t.Id)
        ...;
