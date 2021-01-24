    public partial class AddCallerLanguageChoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LanguageChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            string TempKey = Guid.NewGuid ( ).ToString();
			this.Sql ( String.Format ( "Insert into dbo.LanguageChoices({0},{1})", TempKey, "Initial" ) );
            AddColumn("dbo.Callers", "LanguageChoice_Id", c => c.Guid(nullable: false));
            Sql ( String.Format ( "Update dbo.Callers set LanguageChoice_Id='{0}' where LanguageChoice_Id is null", TempKey ) );
            
            CreateIndex("dbo.Callers", "LanguageChoice_Id");
            AddForeignKey("dbo.Callers", "LanguageChoice_Id", "dbo.LanguageChoices", "Id", cascadeDelete: true);
        }
    
        public override void Down()
        {
            DropForeignKey("dbo.Callers", "LanguageChoice_Id", "dbo.LanguageChoices");
            DropIndex("dbo.Callers", new[] { "LanguageChoice_Id" });
            DropColumn("dbo.Callers", "LanguageChoice_Id");
            DropTable("dbo.LanguageChoices");
        }
    }
