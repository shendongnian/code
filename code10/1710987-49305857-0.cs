    public partial class project: DbMigration
    {
    public override void Up()
    {
        CreateTable("dbo.Documents", c => new
        {
            DocumentId = c.Int(nullable: false, identity: true),
            Label = c.Int(nullable: false),
            Data = c.Binary(),
            OrderId = c.Int(nullable: false)
        }).PrimaryKey(t => t.DocumentId)
        .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true);
