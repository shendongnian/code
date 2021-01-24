    public partial class EcommerceCart_User_Index : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EcommerceCarts", new[] { "User_Id" });
            Sql(
                @"CREATE UNIQUE NONCLUSTERED INDEX IX_User_Id
                ON dbo.EcommerceCarts(User_Id)
                WHERE User_Id IS NOT NULL");
        }
    }
