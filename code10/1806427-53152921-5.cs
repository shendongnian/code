        using System;
        using System.Data.Entity.Migrations;
    
        public partial class EconomyInfo : DbMigration
        {
            public override void Up()
            {
                CreateTable(
                    "dbo.EconomyInfoes",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        
                        LogoImage_Id = c.Int(nullable: false),
                        Organization_Id = c.Int(nullable: false),
    
                    })
                    .PrimaryKey(t => t.Id)
                    .ForeignKey("dbo.Images", t => t.LogoImage_Id)
                    .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                    .Index(t => t.LogoImage_Id)
                    .Index(t => t.Organization_Id);
    
            }
    
            public override void Down()
            {
                DropForeignKey("dbo.EconomyInfoes", "Organization_Id", "dbo.Organizations");
                DropForeignKey("dbo.EconomyInfoes", "LogoImage_Id", "dbo.Images");
                DropIndex("dbo.EconomyInfoes", new[] { "Organization_Id" });
                DropIndex("dbo.EconomyInfoes", new[] { "LogoImage_Id" });
                DropTable("dbo.EconomyInfoes");
            }
        }
