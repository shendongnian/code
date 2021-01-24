    public override void Up()
    {
                CreateTable(
                    "dbo.Users",
                    c => new
                        {
                            Id = c.Int(nullable: false, identity: true),
                            FirstName = c.String(),
                            LastName = c.String(),
                            CreatedBy = c.String(maxLength: 255, unicode: false),
                            CreatedDate = c.Int(),
                            UpdateBy = c.String(maxLength: 255, unicode: false),
                            UpdatedDate = c.Int(),
                        })
                    .PrimaryKey(t => t.Id);
                
      }
