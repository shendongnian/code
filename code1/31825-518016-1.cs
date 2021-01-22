    [Migration(62)]
    public class _62_add_date_created_column : Migration
    {
        public void Up()
        {
           //add it nullable
           Database.AddColumn("Customers", new Column("DateCreated", DateTime) );
    
           //seed it with data
           Database.Execute("update Customers set DateCreated = getdate()");
    
           //add not-null constraint
           Database.AddNotNullConstraint("Customers", "DateCreated");
        }
    
        public void Down()
        {
           Database.RemoveColumn("Customers", "DateCreated");
        }
    }
