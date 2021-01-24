	public override void Up()
	{
		DropForeignKey("dbo.InvoiceSamples", "InvoiceStatusId", "dbo.InvoiceStatus");
		DropIndex("dbo.InvoiceSamples", new[] { "InvoiceStatusId" });
		DropPrimaryKey("dbo.InvoiceSamples");   //Moved up
		RenameColumn(table: "dbo.InvoiceSamples", name: "Id", newName: "OldId");    //Instead of DropColumn
		RenameColumn(table: "dbo.InvoiceSamples", name: "InvoiceStatusId", newName: "Id");  //This will be the new PK
		AlterColumn("dbo.InvoiceSamples", "Id", c => c.Int(nullable: false, identity: true));
		AddPrimaryKey("dbo.InvoiceSamples", "Id");
		CreateIndex("dbo.InvoiceSamples", "Id");
		AddForeignKey("dbo.InvoiceSamples", "Id", "dbo.InvoiceStatus", "Id");
		DropColumn("dbo.InvoiceSamples", "OldId");  //Now we can delete the old PK column
	}
	public override void Down()
	{
		DropForeignKey("dbo.InvoiceSamples", "Id", "dbo.InvoiceStatus");
		DropIndex("dbo.InvoiceSamples", new[] { "Id" });
		DropPrimaryKey("dbo.InvoiceSamples");
		RenameColumn(table: "dbo.InvoiceSamples", name: "Id", newName: "InvoiceStatusId");
		AlterColumn("dbo.InvoiceSamples", "InvoiceStatusId", c => c.Int(nullable: false, identity: false));
		AddColumn("dbo.InvoiceSamples", "Id", c => c.Int(nullable: false, identity: true));
		AlterColumn("dbo.InvoiceSamples", "Id", c => c.Int(nullable: false, identity: true));
		AddPrimaryKey("dbo.InvoiceSamples", "Id");
		CreateIndex("dbo.InvoiceSamples", "InvoiceStatusId");
		AddForeignKey("dbo.InvoiceSamples", "InvoiceStatusId", "dbo.InvoiceStatus", "Id", cascadeDelete: true);
	}
